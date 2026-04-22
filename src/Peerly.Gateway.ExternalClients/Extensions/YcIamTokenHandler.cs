using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Peerly.Gateway.ExternalClients.Extensions;

/// <summary>
/// Подмешивает в исходящий gRPC-запрос IAM-токен, взятый из YC metadata endpoint'а
/// (169.254.169.254). Нужен, чтобы контейнер gateway мог вызывать приватные контейнеры
/// auth/core (YC edge требует Authorization: Bearer для проверки invoker-роли).
/// Вне YC (локально) endpoint недоступен — тогда заголовок не подставляется, это ок.
/// </summary>
internal sealed class YcIamTokenHandler : DelegatingHandler
{
    private const string MetadataUrl =
        "http://169.254.169.254/computeMetadata/v1/instance/service-accounts/default/token";

    private static readonly HttpClient MetadataClient = new()
    {
        Timeout = TimeSpan.FromSeconds(2),
    };

    private static readonly SemaphoreSlim RefreshLock = new(1, 1);
    private static string? _cachedToken;
    private static DateTimeOffset _tokenExpiresAt;

    private readonly ILogger<YcIamTokenHandler> _logger;

    public YcIamTokenHandler(ILogger<YcIamTokenHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await TryGetTokenAsync(cancellationToken);
        if (token is not null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string?> TryGetTokenAsync(CancellationToken ct)
    {
        if (_cachedToken is not null && DateTimeOffset.UtcNow < _tokenExpiresAt)
        {
            return _cachedToken;
        }

        await RefreshLock.WaitAsync(ct);
        try
        {
            if (_cachedToken is not null && DateTimeOffset.UtcNow < _tokenExpiresAt)
            {
                return _cachedToken;
            }

            using var req = new HttpRequestMessage(HttpMethod.Get, MetadataUrl);
            req.Headers.Add("Metadata-Flavor", "Google");

            using var resp = await MetadataClient.SendAsync(req, ct);
            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogDebug("YC metadata endpoint returned {Status}", resp.StatusCode);
                return null;
            }

            var payload = await resp.Content.ReadFromJsonAsync<MetadataResponse>(ct);
            if (payload is null || string.IsNullOrEmpty(payload.AccessToken))
            {
                return null;
            }

            _cachedToken = payload.AccessToken;
            _tokenExpiresAt = DateTimeOffset.UtcNow.AddSeconds(Math.Max(60, payload.ExpiresIn - 60));
            return _cachedToken;
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            _logger.LogDebug(ex, "YC metadata endpoint unreachable");
            return null;
        }
        finally
        {
            RefreshLock.Release();
        }
    }

    private sealed record MetadataResponse(
        [property: JsonPropertyName("access_token")] string AccessToken,
        [property: JsonPropertyName("expires_in")] int ExpiresIn,
        [property: JsonPropertyName("token_type")] string TokenType);
}

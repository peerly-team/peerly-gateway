using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Hosting.Auth.Cookies;

internal sealed class AuthCookiesWriter : IAuthCookiesManager
{
    private const string RootPath = "/";

    private readonly AuthCookieOptions _options;

    public AuthCookiesWriter(IOptionsSnapshot<AuthCookieOptions> options)
    {
        _options = options.Value;
    }

    public void WriteTokens(HttpResponse response, AuthToken token)
    {
        response.Cookies.Append(_options.AccessName, token.AccessToken, BuildCookieOptions(RootPath));
        response.Cookies.Append(_options.RefreshName, token.RefreshToken, BuildCookieOptions(_options.RefreshPath));
    }

    public bool TryGetRefreshToken(HttpRequest request, out string? refreshToken)
    {
        return request.Cookies.TryGetValue(_options.RefreshName, out refreshToken)
               && !string.IsNullOrWhiteSpace(refreshToken);
    }

    public void ClearTokens(HttpResponse response)
    {
        response.Cookies.Delete(_options.AccessName, BuildCookieOptions(RootPath));
        response.Cookies.Delete(_options.RefreshName, BuildCookieOptions(_options.RefreshPath));
    }

    private CookieOptions BuildCookieOptions(string path)
    {
        return new CookieOptions
        {
            HttpOnly = true,
            IsEssential = true,
            Path = path,
            SameSite = _options.SameSite,
            Secure = _options.Secure
        };
    }
}

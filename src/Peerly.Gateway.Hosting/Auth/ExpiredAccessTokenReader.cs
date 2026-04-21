using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Hosting.Auth.Configurations;
using Peerly.Gateway.Hosting.Auth.Cookies;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Abstractions;

namespace Peerly.Gateway.Hosting.Auth;

internal sealed class ExpiredAccessTokenReader : IExpiredAccessTokenReader
{
    private const string JwtPrefix = "Bearer ";

    private readonly IJwksProvider _jwksProvider;
    private readonly AuthHandlerOptions _options;
    private readonly AuthCookieOptions _cookieOptions;

    public ExpiredAccessTokenReader(
        IJwksProvider jwksProvider,
        IOptionsMonitor<AuthHandlerOptions> options,
        IOptionsSnapshot<AuthCookieOptions> cookieOptions)
    {
        _jwksProvider = jwksProvider;
        _options = options.CurrentValue;
        _cookieOptions = cookieOptions.Value;
    }

    public async Task<long?> TryGetUserIdAsync(HttpRequest request, CancellationToken cancellationToken)
    {
        if (!TryGetJwt(request, out var jwt))
        {
            return null;
        }

        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtSecurityToken;
        try
        {
            jwtSecurityToken = handler.ReadJwtToken(jwt);
        }
        catch (ArgumentException)
        {
            return null;
        }
        catch (SecurityTokenException)
        {
            return null;
        }

        var signingKeys = await GetSecurityKeysForKidAsync(jwtSecurityToken.Header.Kid, cancellationToken);
        if (signingKeys.Count == 0)
        {
            return null;
        }

        ClaimsPrincipal principal;
        try
        {
            principal = handler.ValidateToken(
                jwt,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _options.ValidIssuer,
                    ValidateAudience = true,
                    ValidAudience = _options.ValidAudience,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = signingKeys,
                    ValidAlgorithms = _options.ValidAlgorithms
                },
                out _);
        }
        catch (SecurityTokenException)
        {
            return null;
        }

        var userIdClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim))
            return null;

        return long.TryParse(userIdClaim, NumberStyles.Integer, CultureInfo.InvariantCulture, out var userId)
            ? userId
            : null;
    }

    private async Task<IReadOnlyCollection<SecurityKey>> GetSecurityKeysForKidAsync(string? kid, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(kid))
        {
            return [];
        }

        var keys = await _jwksProvider.GetAsync(cancellationToken);
        var keysForKid = keys
            .Where(k => string.Equals(k.KeyId, kid, StringComparison.Ordinal))
            .ToArray();

        if (keysForKid.Length == 0)
        {
            keys = await _jwksProvider.RefreshJwksAsync(cancellationToken);
            keysForKid = keys
                .Where(k => string.Equals(k.KeyId, kid, StringComparison.Ordinal))
                .ToArray();
        }

        return keysForKid;
    }

    private bool TryGetJwt(HttpRequest request, out string jwt)
    {
        if (TryGetJwtFromAuthorization(request, out jwt))
            return true;

        if (TryGetJwtFromAccessCookie(request, out jwt))
            return true;

        jwt = string.Empty;
        return false;
    }

    private static bool TryGetJwtFromAuthorization(HttpRequest request, out string jwt)
    {
        jwt = string.Empty;
        var auth = request.Headers.Authorization.ToString();

        if (string.IsNullOrWhiteSpace(auth) || !auth.StartsWith(JwtPrefix, StringComparison.OrdinalIgnoreCase))
            return false;

        var value = auth[JwtPrefix.Length..].Trim();
        if (string.IsNullOrWhiteSpace(value))
            return false;

        jwt = value;
        return true;
    }

    private bool TryGetJwtFromAccessCookie(HttpRequest request, out string jwt)
    {
        jwt = string.Empty;

        if (!request.Cookies.TryGetValue(_cookieOptions.AccessName, out var value) || string.IsNullOrWhiteSpace(value))
            return false;

        var trimmed = value.Trim();
        if (string.IsNullOrWhiteSpace(trimmed))
            return false;

        jwt = trimmed;
        return true;
    }
}

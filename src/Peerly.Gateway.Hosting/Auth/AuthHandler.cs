using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Peerly.Gateway.Hosting.Auth.Configurations;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Abstractions;

namespace Peerly.Gateway.Hosting.Auth;

public sealed class AuthHandler : AuthenticationHandler<AuthHandlerOptions>
{
    private const string JwtPrefix = "Bearer ";

    private readonly IJwksProvider _jwksProvider;
    private readonly AuthHandlerOptions _options;

    public AuthHandler(
        IOptionsMonitor<AuthHandlerOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IJwksProvider jwksProvider)
        : base(options, logger, encoder)
    {
        ArgumentNullException.ThrowIfNull(options);

        _jwksProvider = jwksProvider;
        _options = options.CurrentValue;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var handler = new JwtSecurityTokenHandler();
        if (!TryGetJwtSecurityToken(handler, out var jwt, out var jwtSecurityToken))
        {
            return AuthenticateResult.Fail("Invalid authorization token");
        }

        var signingKeys = await GetSecurityKeysForKidAsync(jwtSecurityToken!.Header.Kid, Context.RequestAborted);
        if (signingKeys.Count == 0)
        {
            return AuthenticateResult.Fail("Invalid authorization token");
        }

        try
        {
            var principal = handler.ValidateToken(
                jwt,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _options.ValidIssuer,
                    ValidateAudience = true,
                    ValidAudience = _options.ValidAudience,
                    ValidateLifetime = true,
                    ClockSkew = _options.ClockSkew,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = signingKeys,
                    ValidAlgorithms = _options.ValidAlgorithms
                },
                out _);

            if (principal.Identity is not ClaimsIdentity identity || string.IsNullOrWhiteSpace(identity.AuthenticationType))
            {
                principal = new ClaimsPrincipal(new ClaimsIdentity(principal.Claims, Scheme.Name));
            }

            return AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name));
        }
        catch (SecurityTokenException ex)
        {
            return AuthenticateResult.Fail(ex);
        }
    }

    private bool TryGetJwtSecurityToken(JwtSecurityTokenHandler handler, out string? jwt, out JwtSecurityToken? jwtSecurityToken)
    {
        jwtSecurityToken = null;
        jwt = null;

        if (!TryGetJwtFromAuthorization(out jwt) || string.IsNullOrWhiteSpace(jwt))
        {
            return false;
        }

        try
        {
            jwtSecurityToken = handler.ReadJwtToken(jwt);
            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

    private async Task<IReadOnlyCollection<SecurityKey>> GetSecurityKeysForKidAsync(string? kid, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(kid))
            return [];

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

    private bool TryGetJwtFromAuthorization(out string? jwt)
    {
        jwt = null;
        var auth = Request.Headers.Authorization.ToString();

        if (string.IsNullOrWhiteSpace(auth) || !auth.StartsWith(JwtPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        jwt = auth[JwtPrefix.Length..].Trim();
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return false;
        }

        return true;
    }
}

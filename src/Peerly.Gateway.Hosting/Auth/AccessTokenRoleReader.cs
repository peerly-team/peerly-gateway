using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Hosting.Auth;

internal sealed class AccessTokenRoleReader : IAccessTokenRoleReader
{
    private const string RoleClaimType = "role";

    public Role ReadRole(string accessToken)
    {
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
        var roleClaim = jwt.Claims.FirstOrDefault(c => c.Type == RoleClaimType)?.Value
            ?? throw new InvalidOperationException("Access token is missing role claim");
        return Enum.Parse<Role>(roleClaim);
    }
}

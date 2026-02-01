using Microsoft.AspNetCore.Authorization;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Hosting.Auth.Requirements;

internal sealed class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(ApiPermission permission)
    {
        Permission = permission;
    }

    public ApiPermission Permission { get; }
}

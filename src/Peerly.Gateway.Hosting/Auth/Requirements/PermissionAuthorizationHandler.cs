using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Hosting.Auth.Requirements;

internal sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly ICurrentUserContext _currentUserContext;
    private readonly ILogger<PermissionAuthorizationHandler> _logger;
    private readonly IPermissionProvider _permissionProvider;

    public PermissionAuthorizationHandler(
        ICurrentUserContext currentUserContext,
        IPermissionProvider permissionProvider,
        ILogger<PermissionAuthorizationHandler> logger)
    {
        _currentUserContext = currentUserContext;
        _logger = logger;
        _permissionProvider = permissionProvider;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var requiredPermission = requirement.Permission;
        var availablePermissions = _permissionProvider
            .GetPermissions(_currentUserContext.Roles);
        if (_currentUserContext.IsAuthenticated && availablePermissions.Contains(requiredPermission))
        {
            context.Succeed(requirement);
        }
        else
        {
            _logger.LogError(
                """
                Not authenticated request!
                User Name: {UserName};
                Required permission: {RequiredPermissions};
                User's roles: [{UserRoles}];
                User's permissions: [{UserPermissions}]
                """,
                _currentUserContext.UserName,
                requiredPermission,
                string.Join(',', _currentUserContext.Roles),
                string.Join(',', availablePermissions));
        }

        return Task.CompletedTask;
    }
}

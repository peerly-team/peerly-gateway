using Microsoft.AspNetCore.Authorization;

namespace Peerly.Gateway.Api.Infrastructure;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(ApiPermission apiPermission) : base(policy: $"{apiPermission:G}")
    {
    }
}

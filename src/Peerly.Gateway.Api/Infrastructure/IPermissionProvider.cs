using System.Collections.Generic;

namespace Peerly.Gateway.Api.Infrastructure;

public interface IPermissionProvider
{
    IReadOnlySet<ApiPermission> GetPermissions(IEnumerable<string> roles);
}

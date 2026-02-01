using System;
using System.Collections.Generic;
using System.Linq;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Hosting.Auth.Data;

namespace Peerly.Gateway.Hosting.Auth.Services;

public sealed class PermissionProvider : IPermissionProvider
{
    private static readonly string[] s_allRoles = [Role.Admin, Role.Student, Role.Teacher];

    private static readonly Dictionary<ApiPermission, string[]> s_permissionsRolesMapping = new()
    {
        // Storage
        [ApiPermission.GenerateUploadUrl] = s_allRoles,
    };

    private static readonly ILookup<string, ApiPermission> s_rolePermissionMapping;

    static PermissionProvider()
    {
        s_rolePermissionMapping = s_permissionsRolesMapping
            .SelectMany(pair => pair.Value.Select(role => (permission: pair.Key, role)))
            .ToLookup(t => t.role, t => t.permission);
    }

    public IReadOnlySet<ApiPermission> GetPermissions(IEnumerable<string> roles)
    {
        ArgumentNullException.ThrowIfNull(roles, nameof(roles));

        return roles
            .SelectMany(role => s_rolePermissionMapping[role])
            .ToHashSet();
    }
}

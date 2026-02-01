using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Hosting.Auth.Requirements;

namespace Peerly.Gateway.Hosting.Auth.Services;

public sealed class AuthPermissionPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private readonly IReadOnlySet<string> _availablePermissions = Enum.GetNames<ApiPermission>().ToHashSet();
    private readonly ConcurrentDictionary<string, AuthorizationPolicy> _cache = new();

    public AuthPermissionPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        return _availablePermissions.Contains(policyName)
            ? _cache.GetOrAdd(
                policyName,
                _ =>
                {
                    var permission = Enum.Parse<ApiPermission>(policyName);
                    return new AuthorizationPolicyBuilder()
                        .AddRequirements(new PermissionRequirement(permission))
                        .Build();
                })
            : await base.GetPolicyAsync(policyName);
    }
}

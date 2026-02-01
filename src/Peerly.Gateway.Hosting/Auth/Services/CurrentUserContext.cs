using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Hosting.Auth.Configurations;

namespace Peerly.Gateway.Hosting.Auth.Services;

public sealed class CurrentUserContext : ICurrentUserContext
{
    private const string ResourceAccessClaimType = "resource_access";
    private const string RolesKeyName = "roles";

    private readonly Lazy<bool> _isAuthenticated;
    private readonly Lazy<string?> _userName;
    private readonly Lazy<IReadOnlyCollection<string>> _roles;

    public CurrentUserContext(
        IHttpContextAccessor httpContextAccessor,
        IOptions<AuthConfiguration> authConfiguration,
        ILogger<CurrentUserContext> logger)
    {
        var user = httpContextAccessor.HttpContext?.User;
        _isAuthenticated = new Lazy<bool>(() => user?.Identity?.IsAuthenticated is true);
        _userName = new Lazy<string?>(() => user?.FindFirstValue(JwtClaimTypes.PreferredUserName));
        _roles = new Lazy<IReadOnlyCollection<string>>(
            () =>
            {
                var resourceAccess = user?.FindFirstValue(ResourceAccessClaimType);
                if (string.IsNullOrWhiteSpace(resourceAccess))
                {
                    return [];
                }

                try
                {
                    var roles = JsonNode.Parse(resourceAccess)
                        ?[authConfiguration.Value.ClientId]
                        ?[RolesKeyName]
                        ?.AsArray()
                        .Where(x => x is not null)
                        .Select(x => x!.GetValue<string>())
                        .ToArray() ?? [];

                    return roles.AsReadOnly();
                }
                catch (JsonException ex)
                {
                    logger.LogError(ex, "Error parsing roles, claim value: {ResourceAccess}", resourceAccess);
                }

                return [];
            });
    }

    public bool IsAuthenticated => _isAuthenticated.Value;
    public string? UserName => _userName.Value;
    public IReadOnlyCollection<string> Roles => _roles.Value;
}

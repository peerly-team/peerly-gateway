using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Hosting.Auth.Configurations;
using Peerly.Gateway.Hosting.Auth.Data;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.Hosting.Auth;

[ExcludeFromCodeCoverage]
internal sealed class AuthInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        services
            .AddOptions<AuthHandlerOptions>()
            .BindConfiguration(AuthHandlerOptions.SectionName);

        services.AddHttpContextAccessor();
        services.AddMemoryCache();
        services
            .AddAuthorizationBuilder()
            .AddPolicy(ApiPermission.GenerateUploadUrl.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.Logout.ToString(), p => p.RequireRole(Role.AllRoles))
            .AddPolicy(ApiPermission.Refresh.ToString(), p => p.RequireRole(Role.AllRoles));
        services
            .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = "Jwt";
                    options.DefaultChallengeScheme = "Jwt";
                })
            .AddScheme<AuthHandlerOptions, AuthHandler>("Jwt", _ => {});
    }
}

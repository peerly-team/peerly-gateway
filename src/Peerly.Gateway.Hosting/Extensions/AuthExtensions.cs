using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Hosting.Auth.Configurations;
using Peerly.Gateway.Hosting.Auth.Requirements;
using Peerly.Gateway.Hosting.Auth.Services;

namespace Peerly.Gateway.Hosting.Extensions;

internal static class AuthExtensions
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
    {
        services.AddOptions<AuthConfiguration>().BindConfiguration(AuthConfiguration.SectionName);

        return services;
    }

    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services
            .AddAuthorization()
            .AddAuthentication("SSO")
            .AddJwtBearer(
                "SSO",
                options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://localhost:5002",
                        ValidateAudience = true,
                        ValidAudience = "peerly-gateway",
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                });

        services.AddScoped<ICurrentUserContext, CurrentUserContext>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, AuthPermissionPolicyProvider>();
        services.AddScoped<IPermissionProvider, PermissionProvider>();

        return services;
    }
}

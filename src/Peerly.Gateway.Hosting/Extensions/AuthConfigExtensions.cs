using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Hosting.Auth;
using Peerly.Gateway.Hosting.Swagger;

namespace Peerly.Gateway.Hosting.Extensions;

public static class AuthConfigExtensions
{
    public static IServiceCollection AddAuthConfig(this IServiceCollection services)
    {
        const string SsoAuthSchemes = "SSO";

        services.AddSingleton<PeerlyJwtBearerEvents>();
        services.PostConfigure<JwtBearerOptions>(
            SsoAuthSchemes,
            options =>
            {
                options.EventsType = typeof(PeerlyJwtBearerEvents);
            });

        services.ConfigureSwaggerGen(
            o =>
            {
                o.SchemaFilter<RequiredMemberSchemaFilter>();
                o.SupportNonNullableReferenceTypes();
                o.UseOneOfForPolymorphism();
            });

        return services;
    }
}

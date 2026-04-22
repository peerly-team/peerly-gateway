using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Peerly.Gateway.Hosting.Middlewares;

namespace Peerly.Gateway.Hosting.Extensions;

public static class ProgramConfigureExtensions
{
    public static void Configure(this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseMiddleware<CloudflareAccessMiddleware>();

        var config = app.ApplicationServices.GetRequiredService<IConfiguration>();
        var allowedOrigins = config.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
        var allowedOriginSuffixes = config.GetSection("Cors:AllowedOriginSuffixes").Get<string[]>() ?? [];

        app.UseCors(
            policyBuilder => policyBuilder
                .SetIsOriginAllowed(origin =>
                {
                    if (allowedOrigins.Contains(origin, StringComparer.OrdinalIgnoreCase))
                        return true;

                    var host = new Uri(origin).Host;
                    return allowedOriginSuffixes.Any(suffix =>
                        host.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
                })
                .AllowAnyHeader()
                .AllowCredentials()
                .WithMethods("GET", "POST", "PUT", "DELETE")
                .WithExposedHeaders(HeaderNames.ContentDisposition));

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseStatusCodePages();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.UseMiddleware<Peerly.Gateway.Hosting.Middlewares.SwaggerBasicAuthMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peerly Gateway API v1");
            c.RoutePrefix = "swagger";
        });

        app.Use(async (ctx, next) =>
        {
            if (ctx.Request.Path == "/")
            {
                ctx.Response.Redirect("/swagger");
                return;
            }
            await next();
        });
    }
}

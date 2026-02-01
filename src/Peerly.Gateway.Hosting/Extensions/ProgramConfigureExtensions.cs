using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;

namespace Peerly.Gateway.Hosting.Extensions;

public static class ProgramConfigureExtensions
{
    public static void Configure(this IApplicationBuilder app)
    {
        app.UseRouting();

        // todo: настроить безопасную доступ (.SetIsOriginAllowed(_ => true) - небезопасно)
        // можно сделать чтение доступных адресов из appsettings.json
        app.UseCors(
            policyBuilder => policyBuilder
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowCredentials()
                .WithMethods("GET", "POST", "PUT", "DELETE")
                .WithExposedHeaders(HeaderNames.ContentDisposition));

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseStatusCodePages();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

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

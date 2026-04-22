using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Peerly.Gateway.Hosting.Middlewares;

public class SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration config)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/swagger"))
        {
            await next(context);
            return;
        }

        var username = config["Swagger:Username"];
        var password = config["Swagger:Password"];

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await next(context);
            return;
        }

        if (!TryAuthenticate(context, username, password))
        {
            context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"Swagger\"";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }

        await next(context);
    }

    private static bool TryAuthenticate(HttpContext context, string expectedUsername, string expectedPassword)
    {
        var authHeader = context.Request.Headers.Authorization.ToString();
        if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            return false;

        try
        {
            var encoded = authHeader["Basic ".Length..].Trim();
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var parts = decoded.Split(':', 2);
            return parts.Length == 2 && parts[0] == expectedUsername && parts[1] == expectedPassword;
        }
        catch
        {
            return false;
        }
    }
}

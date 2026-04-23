using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Peerly.Gateway.Hosting.Middlewares;

public class OriginKeyMiddleware(RequestDelegate next, IConfiguration config)
{
    private const string HeaderName = "X-Peerly-Gateway-Key";

    public async Task InvokeAsync(HttpContext context)
    {
        if (HttpMethods.IsOptions(context.Request.Method)
            && context.Request.Headers.ContainsKey("Access-Control-Request-Method"))
        {
            await next(context);
            return;
        }

        var expected = config["OriginKey:Secret"];

        if (string.IsNullOrEmpty(expected))
        {
            await next(context);
            return;
        }

        var provided = context.Request.Headers[HeaderName].ToString();

        if (!ConstantTimeEquals(provided, expected))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return;
        }

        await next(context);
    }

    private static bool ConstantTimeEquals(string a, string b)
    {
        var aBytes = Encoding.UTF8.GetBytes(a);
        var bBytes = Encoding.UTF8.GetBytes(b);
        return CryptographicOperations.FixedTimeEquals(aBytes, bBytes);
    }
}

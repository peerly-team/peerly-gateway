using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Peerly.Gateway.Hosting.Middlewares;

public class CloudflareAccessMiddleware(RequestDelegate next, IConfiguration config)
{
    private const string HeaderName = "X-CF-Secret";

    public async Task InvokeAsync(HttpContext context)
    {
        var expected = config["CloudflareAccess:Secret"];

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

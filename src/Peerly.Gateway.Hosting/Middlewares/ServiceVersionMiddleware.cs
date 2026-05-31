using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Peerly.Gateway.ExternalClients.ServiceVersions;

namespace Peerly.Gateway.Hosting.Middlewares;

public sealed class ServiceVersionMiddleware(
    RequestDelegate next,
    IHostEnvironment env)
{
    private const string HeaderName = "X-Peerly-Service-Versions";

    public async Task InvokeAsync(HttpContext ctx, IServiceVersionContext versionContext)
    {
        if (!env.IsStaging())
        {
            await next(ctx);
            return;
        }

        if (ctx.Request.Headers.TryGetValue(HeaderName, out var raw) && raw.Count > 0)
        {
            var parsed = Parse(raw.ToString());
            if (parsed.Count > 0)
                versionContext.Set(parsed);
        }

        await next(ctx);
    }

    private static IReadOnlyDictionary<string, string> Parse(string value)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var entry in value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var eq = entry.IndexOf('=');
            if (eq <= 0 || eq == entry.Length - 1) continue;
            var key = entry[..eq].Trim();
            var tag = entry[(eq + 1)..].Trim();
            if (key.Length == 0 || tag.Length == 0) continue;
            result[key] = tag;
        }
        return result;
    }
}

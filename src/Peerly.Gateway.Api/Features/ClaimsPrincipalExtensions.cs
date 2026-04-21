using System;
using System.Globalization;
using System.Security.Claims;

namespace Peerly.Gateway.Api.Features;

internal static class ClaimsPrincipalExtensions
{
    public static long GetUserId(this ClaimsPrincipal user)
    {
        var value = user.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new InvalidOperationException($"ClaimsPrincipal is missing required '{ClaimTypes.NameIdentifier}' claim.");

        return long.Parse(value, CultureInfo.InvariantCulture);
    }
}

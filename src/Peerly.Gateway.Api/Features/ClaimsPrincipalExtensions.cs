using System.Security.Claims;

namespace Peerly.Gateway.Api.Features;

internal static class ClaimsPrincipalExtensions
{
    public static long GetUserId(this ClaimsPrincipal user)
    {
        return long.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}

using System.Collections.Generic;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks.Models;

public sealed record GetJwksQueryResponse
{
    public required IReadOnlyCollection<string> Jwks { get; init; }
}

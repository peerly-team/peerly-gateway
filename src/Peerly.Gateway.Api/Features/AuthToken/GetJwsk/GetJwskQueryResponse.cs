namespace Peerly.Gateway.Api.Features.AuthToken.GetJwsk;

public sealed record GetJwksQueryResponse
{
    public required string JwksJson { get; init; }
    public required long CacheTtlSeconds { get; init; }
}

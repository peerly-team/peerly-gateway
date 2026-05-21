namespace Peerly.Gateway.Api.Features.Auth.Register;

public sealed record RegisterCommandResponse
{
    public required long UserId { get; init; }
}

public sealed record RegisterResponseBody
{
    public required long UserId { get; init; }
}

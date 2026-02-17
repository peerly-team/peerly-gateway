using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Users.Register;

public sealed record RegisterCommandResponse
{
    public required long UserId { get; init; }
    public required AuthToken Token { get; init; }
}

// todo: отдавать только UserId в ответе команды
public sealed record RegisterResponseBody
{
    public required long UserId { get; init; }
}

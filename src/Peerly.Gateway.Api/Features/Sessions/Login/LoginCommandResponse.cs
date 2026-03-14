using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Sessions.Login;

public sealed record LoginCommandResponse
{
    public required long UserId { get; init; }
    public required AuthToken Token { get; init; }
}

// todo: отдавать только UserId в ответе команды
public sealed record LoginResponseBody
{
    public required long UserId { get; init; }
}

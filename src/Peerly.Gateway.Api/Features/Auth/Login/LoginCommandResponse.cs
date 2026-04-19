using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Auth.Login;

public sealed record LoginCommandResponse : IAuthTokenResponse
{
    public required long UserId { get; init; }
    public required AuthToken Token { get; init; }
}

public sealed record LoginResponseBody
{
    public required long UserId { get; init; }
}

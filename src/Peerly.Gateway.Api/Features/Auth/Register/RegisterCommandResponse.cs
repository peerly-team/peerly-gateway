using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Auth.Register;

public sealed record RegisterCommandResponse : IAuthTokenResponse
{
    public required long UserId { get; init; }
    public required AuthToken Token { get; init; }
}

public sealed record RegisterResponseBody
{
    public required long UserId { get; init; }
}

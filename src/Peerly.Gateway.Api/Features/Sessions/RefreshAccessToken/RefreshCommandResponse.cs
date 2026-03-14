using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Sessions.RefreshAccessToken;

public sealed record RefreshCommandResponse
{
    public required AuthToken Token { get; init; }
}

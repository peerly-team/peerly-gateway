using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Sessions.RefreshAccessToken;

public sealed record RefreshCommandResponse : IAuthTokenResponse
{
    public required AuthToken Token { get; init; }
}

using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Auth.Refresh;

public sealed record RefreshCommandResponse : IAuthTokenResponse
{
    public required AuthToken Token { get; init; }
}

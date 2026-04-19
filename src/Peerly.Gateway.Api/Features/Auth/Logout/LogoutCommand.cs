using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Logout;

public sealed record LogoutCommand : IRequest<Result<EmptyResponse>>
{
    public required long UserId { get; init; }
    public required string RefreshToken { get; init; }
}

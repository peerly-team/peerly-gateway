using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Refresh;

public sealed record RefreshCommand : IRequest<Result<RefreshCommandResponse>>
{
    public required long UserId { get; init; }
    public required string RefreshToken { get; init; }
}

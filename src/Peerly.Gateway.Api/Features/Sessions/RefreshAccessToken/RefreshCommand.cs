using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions.RefreshAccessToken;

public sealed record RefreshCommand : IRequest<Result<RefreshCommandResponse>>
{
    public required long UserId { get; init; }
    public required RefreshRequestBody RequestBody { get; init; }
}

public sealed record RefreshRequestBody
{
    public required string RefreshToken { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions.Logout;

public sealed record LogoutCommand : IRequest<Result<EmptyResponse>>
{
    public required long UserId { get; init; }
    public required LogoutRequestBody RequestBody { get; init; }
}

public sealed record LogoutRequestBody
{
    public required string RefreshToken { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Users.Register;

public sealed record RegisterCommand : IRequest<Result<RegisterCommandResponse>>
{
    public required RegisterRequestBody RequestBody { get; init; }
}

public sealed record RegisterRequestBody
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string UserName { get; init; }
    public required Role Role { get; init; }
}

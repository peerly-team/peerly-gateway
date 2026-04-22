using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Login;

public sealed record LoginCommand : IRequest<Result<LoginCommandResponse>>
{
    public required LoginRequestBody RequestBody { get; init; }
}

public sealed record LoginRequestBody
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}

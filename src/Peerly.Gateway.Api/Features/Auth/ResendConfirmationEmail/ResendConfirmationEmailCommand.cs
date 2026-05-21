using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.ResendConfirmationEmail;

public sealed record ResendConfirmationEmailCommand : IRequest<Result<EmptyResponse>>
{
    public required ResendConfirmationEmailRequestBody RequestBody { get; init; }
}

public sealed record ResendConfirmationEmailRequestBody
{
    public required string Email { get; init; }
}

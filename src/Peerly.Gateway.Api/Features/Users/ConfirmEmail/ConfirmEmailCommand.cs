using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Users.ConfirmEmail;

public sealed record ConfirmEmailCommand : IRequest<Result<EmptyResponse>>
{
    public required ConfirmEmailFilter Filter { get; init; }
}

public sealed record ConfirmEmailFilter
{
    public required string Token { get; init; }
}

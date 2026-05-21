using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Auth.ConfirmEmail;

public sealed record ConfirmEmailCommandResponse : IAuthTokenResponse
{
    public required long UserId { get; init; }
    public required AuthToken Token { get; init; }
}

public sealed record ConfirmEmailResponseBody
{
    public required long UserId { get; init; }
}

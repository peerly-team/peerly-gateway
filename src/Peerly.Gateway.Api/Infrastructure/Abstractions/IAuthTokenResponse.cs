using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Infrastructure.Abstractions;

public interface IAuthTokenResponse
{
    AuthToken Token { get; }
}

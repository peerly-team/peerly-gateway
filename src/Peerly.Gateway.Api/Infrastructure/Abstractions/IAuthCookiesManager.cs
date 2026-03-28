using Microsoft.AspNetCore.Http;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Infrastructure.Abstractions;

public interface IAuthCookiesManager
{
    void WriteTokens(HttpResponse response, AuthToken token);
    bool TryGetRefreshToken(HttpRequest request, out string? refreshToken);
    void ClearTokens(HttpResponse response);
}

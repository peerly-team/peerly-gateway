using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions.Logout;

public sealed class LogoutHandler : FeatureHandlerAdapter<
    LogoutQuery, EmptyResponse, V1LogoutRequest, V1LogoutResponse>
{
    public LogoutHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1LogoutAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions.Login;

public sealed class LoginHandler : FeatureHandlerAdapter<
    LoginCommand, Result<LoginCommandResponse>, V1LoginRequest, V1LoginResponse>
{
    public LoginHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1LoginAsync, mapper)
    {
    }
}

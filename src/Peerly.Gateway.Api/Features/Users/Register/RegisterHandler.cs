using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Users.Register;

public sealed class RegisterHandler : FeatureHandlerAdapter<
    RegisterCommand, Result<RegisterCommandResponse>, V1RegisterRequest, V1RegisterResponse>
{
    public RegisterHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1RegisterAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Users.ConfirmEmail;

public sealed class ConfirmEmailHandler : FeatureHandlerAdapter<
    ConfirmEmailCommand, Result<EmptyResponse>, V1ConfirmEmailRequest, V1ConfirmEmailResponse>
{
    public ConfirmEmailHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1ConfirmEmailAsync, mapper)
    {
    }
}

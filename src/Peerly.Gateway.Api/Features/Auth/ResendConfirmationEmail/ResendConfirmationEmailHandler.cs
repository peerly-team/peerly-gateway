using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.ResendConfirmationEmail;

public sealed class ResendConfirmationEmailHandler : FeatureHandlerAdapter<
    ResendConfirmationEmailCommand, Result<EmptyResponse>, V1ResendConfirmationEmailRequest, V1ResendConfirmationEmailResponse>
{
    public ResendConfirmationEmailHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1ResendConfirmationEmailAsync, mapper)
    {
    }
}

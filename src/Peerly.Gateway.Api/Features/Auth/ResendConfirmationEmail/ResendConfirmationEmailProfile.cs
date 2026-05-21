using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.ResendConfirmationEmail;

public sealed class ResendConfirmationEmailProfile : Profile
{
    public ResendConfirmationEmailProfile()
    {
        CreateMap<ResendConfirmationEmailCommand, V1ResendConfirmationEmailRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<ResendConfirmationEmailRequestBody, V1ResendConfirmationEmailRequest>();
        CreateMap<V1ResendConfirmationEmailResponse, Result<EmptyResponse>>();
        CreateMap<V1ResendConfirmationEmailResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

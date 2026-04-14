using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Users.ConfirmEmail;

public sealed class ConfirmEmailProfile : Profile
{
    public ConfirmEmailProfile()
    {
        CreateMap<ConfirmEmailCommand, V1ConfirmEmailRequest>()
            .IncludeMembers(c => c.Filter);
        CreateMap<ConfirmEmailFilter, V1ConfirmEmailRequest>();
        CreateMap<V1ConfirmEmailResponse, Result<EmptyResponse>>();
        CreateMap<V1ConfirmEmailResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

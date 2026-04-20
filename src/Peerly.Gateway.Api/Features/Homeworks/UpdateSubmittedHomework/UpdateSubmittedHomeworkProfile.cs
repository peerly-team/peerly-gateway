using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateSubmittedHomework;

public sealed class UpdateSubmittedHomeworkProfile : Profile
{
    public UpdateSubmittedHomeworkProfile()
    {
        CreateMap<UpdateSubmittedHomeworkCommand, V1UpdateSubmittedHomeworkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateSubmittedHomeworkRequestBody, V1UpdateSubmittedHomeworkRequest>();
        CreateMap<V1UpdateSubmittedHomeworkResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateSubmittedHomeworkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

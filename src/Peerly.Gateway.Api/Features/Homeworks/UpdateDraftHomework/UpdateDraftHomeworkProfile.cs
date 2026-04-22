using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateDraftHomework;

public sealed class UpdateDraftHomeworkProfile : Profile
{
    public UpdateDraftHomeworkProfile()
    {
        CreateMap<UpdateDraftHomeworkCommand, V1UpdateDraftHomeworkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateDraftHomeworkRequestBody, V1UpdateDraftHomeworkRequest>();
        CreateMap<V1UpdateDraftHomeworkResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateDraftHomeworkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

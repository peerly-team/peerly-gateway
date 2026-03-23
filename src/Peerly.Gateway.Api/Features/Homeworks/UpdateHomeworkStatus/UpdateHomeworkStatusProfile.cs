using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateHomeworkStatus;

public sealed class UpdateHomeworkStatusProfile : Profile
{
    public UpdateHomeworkStatusProfile()
    {
        CreateMap<UpdateHomeworkStatusCommand, V1UpdateHomeworkStatusRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateHomeworkStatusRequestBody, V1UpdateHomeworkStatusRequest>();
        CreateMap<V1UpdateHomeworkStatusResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateHomeworkStatusResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

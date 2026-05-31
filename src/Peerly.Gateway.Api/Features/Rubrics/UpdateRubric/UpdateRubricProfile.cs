using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.UpdateRubric;

public sealed class UpdateRubricProfile : Profile
{
    public UpdateRubricProfile()
    {
        CreateMap<UpdateRubricCommand, V1UpdateRubricRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateRubricRequestBody, V1UpdateRubricRequest>(MemberList.Source);
        CreateMap<V1UpdateRubricResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateRubricResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

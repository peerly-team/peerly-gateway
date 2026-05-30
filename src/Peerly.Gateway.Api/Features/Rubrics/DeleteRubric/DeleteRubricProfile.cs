using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.DeleteRubric;

public sealed class DeleteRubricProfile : Profile
{
    public DeleteRubricProfile()
    {
        CreateMap<DeleteRubricCommand, V1DeleteRubricRequest>();
        CreateMap<V1DeleteRubricResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteRubricResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

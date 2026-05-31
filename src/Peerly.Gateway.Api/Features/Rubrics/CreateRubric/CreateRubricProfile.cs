using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.CreateRubric;

public sealed class CreateRubricProfile : Profile
{
    public CreateRubricProfile()
    {
        CreateMap<CreateRubricCommand, V1CreateRubricRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateRubricRequestBody, V1CreateRubricRequest>(MemberList.Source);
        CreateMap<V1CreateRubricResponse, Result<CreateRubricCommandResponse>>();
        CreateMap<V1CreateRubricResponse.Types.Success, CreateRubricCommandResponse>(MemberList.Source);
    }
}

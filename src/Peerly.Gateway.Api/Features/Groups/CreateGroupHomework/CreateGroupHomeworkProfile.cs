using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.CreateGroupHomework;

public sealed class CreateGroupHomeworkProfile : Profile
{
    public CreateGroupHomeworkProfile()
    {
        CreateMap<CreateGroupHomeworkCommand, V1CreateGroupHomeworkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateGroupHomeworkRequestBody, V1CreateGroupHomeworkRequest>(MemberList.Source)
            .ForMember(dst => dst.RubricId, opt => opt.Condition(src => src.RubricId.HasValue));
        CreateMap<V1CreateGroupHomeworkResponse, Result<CreateGroupHomeworkCommandResponse>>();
        CreateMap<V1CreateGroupHomeworkResponse.Types.Success, CreateGroupHomeworkCommandResponse>(MemberList.Source);
    }
}

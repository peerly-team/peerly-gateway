using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.UpdateGroup;

public sealed class UpdateGroupProfile : Profile
{
    public UpdateGroupProfile()
    {
        CreateMap<UpdateGroupCommand, V1UpdateGroupRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateGroupRequestBody, V1UpdateGroupRequest>();
        CreateMap<V1UpdateGroupResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateGroupResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

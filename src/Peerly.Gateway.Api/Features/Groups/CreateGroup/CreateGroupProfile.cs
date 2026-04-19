using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.CreateGroup;

public sealed class CreateGroupProfile : Profile
{
    public CreateGroupProfile()
    {
        CreateMap<CreateGroupCommand, V1CreateGroupRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateGroupRequestBody, V1CreateGroupRequest>();
        CreateMap<V1CreateGroupResponse, Result<CreateGroupCommandResponse>>();
        CreateMap<V1CreateGroupResponse.Types.Success, CreateGroupCommandResponse>(MemberList.Source);
    }
}

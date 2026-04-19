using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.DeleteGroup;

public sealed class DeleteGroupProfile : Profile
{
    public DeleteGroupProfile()
    {
        CreateMap<DeleteGroupCommand, V1DeleteGroupRequest>();
        CreateMap<V1DeleteGroupResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteGroupResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

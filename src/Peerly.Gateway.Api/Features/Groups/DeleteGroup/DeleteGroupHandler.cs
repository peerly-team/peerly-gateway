using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.DeleteGroup;

public sealed class DeleteGroupHandler : FeatureHandlerAdapter<
    DeleteGroupCommand, Result<EmptyResponse>, V1DeleteGroupRequest, V1DeleteGroupResponse>
{
    public DeleteGroupHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1DeleteGroupAsync, mapper)
    {
    }
}

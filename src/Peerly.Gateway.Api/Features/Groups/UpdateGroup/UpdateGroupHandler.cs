using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.UpdateGroup;

public sealed class UpdateGroupHandler : FeatureHandlerAdapter<
    UpdateGroupCommand, Result<EmptyResponse>, V1UpdateGroupRequest, V1UpdateGroupResponse>
{
    public UpdateGroupHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1UpdateGroupAsync, mapper)
    {
    }
}

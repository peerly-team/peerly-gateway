using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.CreateGroup;

public sealed class CreateGroupHandler : FeatureHandlerAdapter<
    CreateGroupCommand, Result<CreateGroupCommandResponse>, V1CreateGroupRequest, V1CreateGroupResponse>
{
    public CreateGroupHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1CreateGroupAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherGroup;

public sealed class GetTeacherGroupHandler : FeatureHandlerAdapter<
    GetTeacherGroupQuery, GetTeacherGroupQueryResponse, V1GetTeacherGroupRequest, V1GetTeacherGroupResponse>
{
    public GetTeacherGroupHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1GetTeacherGroupAsync, mapper)
    {
    }
}

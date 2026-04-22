using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentGroup;

public sealed class GetStudentGroupHandler : FeatureHandlerAdapter<
    GetStudentGroupQuery, GetStudentGroupQueryResponse, V1GetStudentGroupRequest, V1GetStudentGroupResponse>
{
    public GetStudentGroupHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1GetStudentGroupAsync, mapper)
    {
    }
}

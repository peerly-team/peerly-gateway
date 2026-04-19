using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseGroups;

public sealed class ListStudentCourseGroupsHandler :
    FeatureHandlerAdapter<ListStudentCourseGroupsQuery, ListStudentCourseGroupsQueryResponse, V1ListStudentCourseGroupsRequest, V1ListStudentCourseGroupsResponse>
{
    public ListStudentCourseGroupsHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1ListStudentCourseGroupsAsync, mapper)
    {
    }
}

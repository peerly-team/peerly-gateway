using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseGroups;

public sealed class ListTeacherCourseGroupsHandler :
    FeatureHandlerAdapter<ListTeacherCourseGroupsQuery, ListTeacherCourseGroupsQueryResponse, V1ListTeacherCourseGroupsRequest, V1ListTeacherCourseGroupsResponse>
{
    public ListTeacherCourseGroupsHandler(GroupService.GroupServiceClient client, IMapper mapper)
        : base(client.V1ListTeacherCourseGroupsAsync, mapper)
    {
    }
}

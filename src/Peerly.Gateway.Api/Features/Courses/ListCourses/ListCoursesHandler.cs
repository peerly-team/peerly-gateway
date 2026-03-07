using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Courses.ListCourses;

public sealed class ListCoursesHandler : FeatureHandlerAdapter<
    ListCoursesQuery, ListCoursesQueryResponse, V1SearchCoursesRequest, V1SearchCoursesResponse>
{
    public ListCoursesHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1SearchCoursesAsync, mapper)
    {
    }
}

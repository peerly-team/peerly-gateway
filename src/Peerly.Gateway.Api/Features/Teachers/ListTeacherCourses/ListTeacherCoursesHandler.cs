using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourses;

public sealed class ListTeacherCoursesHandler : FeatureHandlerAdapter<
    ListTeacherCoursesQuery, ListTeacherCoursesQueryResponse, V1SearchTeacherCoursesRequest, V1SearchTeacherCoursesResponse>
{
    public ListTeacherCoursesHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1SearchTeacherCoursesAsync, mapper)
    {
    }
}

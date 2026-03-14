using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Student.ListStudentCourses;

public sealed class ListStudentCoursesHandler : FeatureHandlerAdapter<
    ListStudentCoursesQuery, ListStudentCoursesQueryResponse, V1SearchStudentCoursesRequest, V1SearchStudentCoursesResponse>
{
    public ListStudentCoursesHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1SearchStudentCoursesAsync, mapper)
    {
    }
}

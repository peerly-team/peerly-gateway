using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Student.GetStudentCourse;

public sealed class GetStudentCourseHandler : FeatureHandlerAdapter<
    GetStudentCourseQuery, GetStudentCourseQueryResponse, V1GetStudentCourseRequest, V1GetStudentCourseResponse>
{
    public GetStudentCourseHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1GetStudentCourseAsync, mapper)
    {
    }
}

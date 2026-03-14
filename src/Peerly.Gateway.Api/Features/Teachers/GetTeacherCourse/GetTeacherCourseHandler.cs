using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;

public sealed class GetTeacherCourseHandler : FeatureHandlerAdapter<
    GetTeacherCourseQuery, GetTeacherCourseQueryResponse, V1GetTeacherCourseRequest, V1GetTeacherCourseResponse>
{
    public GetTeacherCourseHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1GetTeacherCourseAsync, mapper)
    {
    }
}

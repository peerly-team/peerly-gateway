using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.DeleteCourse;

public sealed class DeleteCourseHandler: FeatureHandlerAdapter<
    DeleteCourseCommand, Result<EmptyResponse>, V1DeleteCourseRequest, V1DeleteCourseResponse>
{
    public DeleteCourseHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1DeleteCourseAsync, mapper)
    {
    }
}

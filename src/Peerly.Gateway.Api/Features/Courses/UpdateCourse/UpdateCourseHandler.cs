using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.UpdateCourse;

public sealed class UpdateCourseHandler : FeatureHandlerAdapter<
    UpdateCourseCommand, Result<EmptyResponse>, V1UpdateCourseRequest, V1UpdateCourseResponse>
{
    public UpdateCourseHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1UpdateCourseAsync, mapper)
    {
    }
}

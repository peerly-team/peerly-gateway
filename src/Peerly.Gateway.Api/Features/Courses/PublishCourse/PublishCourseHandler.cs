using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.PublishCourse;

public sealed class PublishCourseHandler : FeatureHandlerAdapter<
    PublishCourseCommand, Result<EmptyResponse>, V1PublishCourseRequest, V1PublishCourseResponse>
{
    public PublishCourseHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1PublishCourseAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourse;

public sealed class CreateCourseHandler : FeatureHandlerAdapter<
    CreateCourseCommand, Result<CreateCourseCommandResponse>, V1CreateCourseRequest, V1CreateCourseResponse>
{
    public CreateCourseHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1CreateCourseAsync, mapper)
    {
    }
}


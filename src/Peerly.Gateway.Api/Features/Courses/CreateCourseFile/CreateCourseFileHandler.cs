using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourseFile;

public sealed class CreateCourseFileHandler : FeatureHandlerAdapter<
    CreateCourseFileCommand, Result<CreateCourseFileCommandResponse>, V1CreateCourseFileRequest, V1CreateCourseFileResponse>
{
    public CreateCourseFileHandler(CourseService.CourseServiceClient client, IMapper mapper)
        : base(client.V1CreateCourseFileAsync, mapper)
    {
    }
}

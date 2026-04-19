using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourseHomework;

public sealed class CreateCourseHomeworkHandler :
    FeatureHandlerAdapter<CreateCourseHomeworkCommand, Result<CreateCourseHomeworkCommandResponse>, V1CreateCourseHomeworkRequest, V1CreateCourseHomeworkResponse>
{
    public CreateCourseHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1CreateCourseHomeworkAsync, mapper)
    {
    }
}

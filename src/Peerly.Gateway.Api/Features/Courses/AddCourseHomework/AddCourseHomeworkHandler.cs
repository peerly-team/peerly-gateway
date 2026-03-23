using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.AddCourseHomework;

public sealed class AddCourseHomeworkHandler : FeatureHandlerAdapter<
    AddCourseHomeworkCommand, Result<AddCourseHomeworkCommandResponse>, V1CreateHomeworkRequest, V1CreateHomeworkResponse>
{
    public AddCourseHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1CreateHomeworkAsync, mapper)
    {
    }
}

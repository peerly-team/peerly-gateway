using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.PostponeHomeworkDeadlines;

public sealed class PostponeHomeworkDeadlinesHandler : FeatureHandlerAdapter<
    PostponeHomeworkDeadlinesCommand, Result<EmptyResponse>, V1PostponeHomeworkDeadlinesRequest, V1PostponeHomeworkDeadlinesResponse>
{
    public PostponeHomeworkDeadlinesHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1PostponeHomeworkDeadlinesAsync, mapper)
    {
    }
}

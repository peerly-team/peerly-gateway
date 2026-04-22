using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.ListSubmittedHomeworkOverview;

public sealed class ListSubmittedHomeworkOverviewHandler :
    FeatureHandlerAdapter<ListSubmittedHomeworkOverviewQuery, ListSubmittedHomeworkOverviewQueryResponse, V1ListSubmittedHomeworkOverviewRequest, V1ListSubmittedHomeworkOverviewResponse>
{
    public ListSubmittedHomeworkOverviewHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1ListSubmittedHomeworkOverviewAsync, mapper)
    {
    }
}

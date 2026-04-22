using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.ListAssignedReviews;

public sealed class ListAssignedReviewsHandler :
    FeatureHandlerAdapter<ListAssignedReviewsQuery, ListAssignedReviewsQueryResponse, V1ListAssignedReviewsRequest, V1ListAssignedReviewsResponse>
{
    public ListAssignedReviewsHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1ListAssignedReviewsAsync, mapper)
    {
    }
}

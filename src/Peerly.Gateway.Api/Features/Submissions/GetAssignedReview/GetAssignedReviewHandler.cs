using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Submissions.GetAssignedReview;

public sealed class GetAssignedReviewHandler :
    FeatureHandlerAdapter<GetAssignedReviewQuery, GetAssignedReviewQueryResponse, V1GetAssignedReviewRequest, V1GetAssignedReviewResponse>
{
    public GetAssignedReviewHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1GetAssignedReviewAsync, mapper)
    {
    }
}

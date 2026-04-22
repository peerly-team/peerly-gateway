using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.GetSubmittedReview;

public sealed class GetSubmittedReviewHandler :
    FeatureHandlerAdapter<GetSubmittedReviewQuery, GetSubmittedReviewQueryResponse, V1GetSubmittedReviewRequest, V1GetSubmittedReviewResponse>
{
    public GetSubmittedReviewHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1GetSubmittedReviewAsync, mapper)
    {
    }
}

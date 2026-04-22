using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Reviews.DeleteSubmittedReview;

public sealed class DeleteSubmittedReviewHandler :
    FeatureHandlerAdapter<DeleteSubmittedReviewCommand, Result<EmptyResponse>, V1DeleteSubmittedReviewRequest, V1DeleteSubmittedReviewResponse>
{
    public DeleteSubmittedReviewHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1DeleteSubmittedReviewAsync, mapper)
    {
    }
}

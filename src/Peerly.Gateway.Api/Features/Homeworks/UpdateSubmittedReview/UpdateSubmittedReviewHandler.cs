using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateSubmittedReview;

public sealed class UpdateSubmittedReviewHandler :
    FeatureHandlerAdapter<UpdateSubmittedReviewCommand, Result<EmptyResponse>, V1UpdateSubmittedReviewRequest, V1UpdateSubmittedReviewResponse>
{
    public UpdateSubmittedReviewHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1UpdateSubmittedReviewAsync, mapper)
    {
    }
}

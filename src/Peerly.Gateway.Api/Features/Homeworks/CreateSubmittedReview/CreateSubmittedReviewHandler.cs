using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedReview;

public sealed class CreateSubmittedReviewHandler : FeatureHandlerAdapter<
    CreateSubmittedReviewCommand, Result<CreateSubmittedReviewCommandResponse>, V1CreateSubmittedReviewRequest, V1CreateSubmittedReviewResponse>
{
    public CreateSubmittedReviewHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1CreateSubmittedReviewAsync, mapper)
    {
    }
}

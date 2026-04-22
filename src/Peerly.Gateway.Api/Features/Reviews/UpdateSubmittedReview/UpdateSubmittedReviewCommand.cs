using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Reviews.UpdateSubmittedReview;

public sealed record UpdateSubmittedReviewCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedReviewId { get; init; }
    public required long StudentId { get; init; }
    public required UpdateSubmittedReviewRequestBody RequestBody { get; init; }
}

public sealed record UpdateSubmittedReviewRequestBody
{
    public required int Mark { get; init; }
    public required string Comment { get; init; }
}

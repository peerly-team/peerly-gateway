using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Reviews.UpdateSubmittedReview;

public sealed record UpdateSubmittedReviewCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedReviewId { get; init; }
    public required long StudentId { get; init; }
    public required UpdateSubmittedReviewRequestBody RequestBody { get; init; }
}

public sealed record UpdateSubmittedReviewRequestBody
{
    public required IReadOnlyList<SubmittedReviewScoreInput> Scores { get; init; }
    public required string Comment { get; init; }
}

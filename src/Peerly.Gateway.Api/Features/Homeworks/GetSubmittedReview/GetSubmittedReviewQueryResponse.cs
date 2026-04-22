using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.GetSubmittedReview;

public sealed record GetSubmittedReviewQueryResponse
{
    public required SubmittedReviewInfo SubmittedReview { get; init; }
}

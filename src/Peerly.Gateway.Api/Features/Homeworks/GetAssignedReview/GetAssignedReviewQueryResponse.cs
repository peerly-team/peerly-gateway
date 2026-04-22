using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.GetAssignedReview;

public sealed record GetAssignedReviewQueryResponse
{
    public required SubmissionForReview Submission { get; init; }
}

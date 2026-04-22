namespace Peerly.Gateway.Api.Features.Submissions.CreateSubmittedReview;

public sealed record CreateSubmittedReviewCommandResponse
{
    public required long SubmittedReviewId { get; init; }
}

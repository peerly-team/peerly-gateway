namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedReview;

public sealed record CreateSubmittedReviewCommandResponse
{
    public required long SubmittedReviewId { get; init; }
}

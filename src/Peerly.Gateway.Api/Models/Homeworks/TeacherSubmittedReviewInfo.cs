using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record TeacherSubmittedReviewInfo
{
    public required SubmittedReviewInfo SubmittedReview { get; init; }
    public required StudentInfo Reviewer { get; init; }
}

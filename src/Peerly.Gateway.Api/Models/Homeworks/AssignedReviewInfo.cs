namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record AssignedReviewInfo
{
    public required long SubmittedHomeworkId { get; init; }
    public required string HomeworkName { get; init; }
    public required bool IsReviewed { get; init; }
}

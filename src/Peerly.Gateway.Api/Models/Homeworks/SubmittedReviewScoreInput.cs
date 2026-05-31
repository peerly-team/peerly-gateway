namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedReviewScoreInput
{
    public required long RubricCriterionId { get; init; }
    public required int Score { get; init; }
    public string? Comment { get; init; }
}

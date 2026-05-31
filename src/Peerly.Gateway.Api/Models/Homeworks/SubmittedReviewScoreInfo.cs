namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedReviewScoreInfo
{
    public required long Id { get; init; }
    public required long RubricCriterionId { get; init; }
    public required int Score { get; init; }
    public string? Comment { get; init; }
}

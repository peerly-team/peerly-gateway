namespace Peerly.Gateway.Api.Models.Rubrics;

public sealed record RubricCriterionInfo
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required int MaxScore { get; init; }
    public required bool CommentRequired { get; init; }
    public required int Position { get; init; }
}

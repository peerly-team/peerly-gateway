namespace Peerly.Gateway.Api.Models.Rubrics;

public sealed record RubricInfo
{
    public required long Id { get; init; }
    public required long TeacherId { get; init; }
    public required string Name { get; init; }
}

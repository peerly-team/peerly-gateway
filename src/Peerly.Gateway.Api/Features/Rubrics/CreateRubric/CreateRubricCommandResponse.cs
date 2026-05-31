namespace Peerly.Gateway.Api.Features.Rubrics.CreateRubric;

public sealed record CreateRubricCommandResponse
{
    public required long RubricId { get; init; }
}

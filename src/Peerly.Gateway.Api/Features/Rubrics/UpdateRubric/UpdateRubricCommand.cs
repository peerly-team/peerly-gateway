using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Rubrics;

namespace Peerly.Gateway.Api.Features.Rubrics.UpdateRubric;

public sealed record UpdateRubricCommand : IRequest<Result<EmptyResponse>>
{
    public required long RubricId { get; init; }
    public required long TeacherId { get; init; }
    public required UpdateRubricRequestBody RequestBody { get; init; }
}

public sealed record UpdateRubricRequestBody
{
    public required string Name { get; init; }
    public required IReadOnlyList<RubricCriterionInput> Criteria { get; init; }
}

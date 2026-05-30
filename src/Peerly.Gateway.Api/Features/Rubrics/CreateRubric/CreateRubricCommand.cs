using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Rubrics;

namespace Peerly.Gateway.Api.Features.Rubrics.CreateRubric;

public sealed record CreateRubricCommand : IRequest<Result<CreateRubricCommandResponse>>
{
    public required long TeacherId { get; init; }
    public required CreateRubricRequestBody RequestBody { get; init; }
}

public sealed record CreateRubricRequestBody
{
    public required string Name { get; init; }
    public required IReadOnlyList<RubricCriterionInput> Criteria { get; init; }
}

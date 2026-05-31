using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Rubrics;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherRubric;

public sealed record GetTeacherRubricQueryResponse
{
    public required RubricInfo Rubric { get; init; }
    public required IReadOnlyList<RubricCriterionInfo> Criteria { get; init; }
}

using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Rubrics;

namespace Peerly.Gateway.Api.Features.Students.GetStudentRubric;

public sealed record GetStudentRubricQueryResponse
{
    public required IReadOnlyList<RubricCriterionInfo> Criteria { get; init; }
}

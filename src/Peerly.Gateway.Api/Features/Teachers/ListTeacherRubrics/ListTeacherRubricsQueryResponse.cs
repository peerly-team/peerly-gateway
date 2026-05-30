using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Rubrics;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherRubrics;

public sealed record ListTeacherRubricsQueryResponse
{
    public required IReadOnlyList<RubricInfo> Rubrics { get; init; }
}

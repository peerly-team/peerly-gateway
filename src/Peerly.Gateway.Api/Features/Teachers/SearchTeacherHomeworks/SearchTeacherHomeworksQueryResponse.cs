using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Teachers.SearchTeacherHomeworks;

public sealed record SearchTeacherHomeworksQueryResponse
{
    public required IReadOnlyCollection<TeacherHomeworkInfo> TeacherHomeworkInfos { get; init; }
}

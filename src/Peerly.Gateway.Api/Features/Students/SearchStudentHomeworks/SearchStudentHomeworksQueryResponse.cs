using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Students.SearchStudentHomeworks;

public sealed record SearchStudentHomeworksQueryResponse
{
    public required IReadOnlyCollection<StudentHomeworkInfo> StudentHomeworkInfos { get; init; }
}

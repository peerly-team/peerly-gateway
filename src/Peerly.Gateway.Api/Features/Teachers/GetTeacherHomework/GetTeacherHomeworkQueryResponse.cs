using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Files;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherHomework;

public sealed record GetTeacherHomeworkQueryResponse
{
    public required HomeworkInfo HomeworkInfo { get; init; }
    public required int SubmittedCount { get; init; }
    public required int TotalStudentsCount { get; init; }
    public required IReadOnlyList<File> Files { get; init; }
}

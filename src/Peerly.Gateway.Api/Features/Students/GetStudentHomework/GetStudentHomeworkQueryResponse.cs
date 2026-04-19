using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Files;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Students.GetStudentHomework;

public sealed record GetStudentHomeworkQueryResponse
{
    public required HomeworkInfo HomeworkInfo { get; init; }
    public long? SubmittedHomeworkId { get; init; }
    public required IReadOnlyList<File> Files { get; init; }
}

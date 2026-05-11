using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Models.Course;

public sealed record CourseInfo
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required string? Description { get; init; }
    public required CourseStatus Status { get; init; }
    public required IReadOnlyCollection<TeacherInfo> Teachers { get; init; }
}

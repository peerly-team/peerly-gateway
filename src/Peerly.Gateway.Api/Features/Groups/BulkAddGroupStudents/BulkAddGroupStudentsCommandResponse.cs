using System.Collections.Generic;

namespace Peerly.Gateway.Api.Features.Groups.BulkAddGroupStudents;

public sealed record BulkAddGroupStudentsCommandResponse
{
    public required IReadOnlyCollection<long> AddedStudentIds { get; init; }
    public required IReadOnlyCollection<BulkAddGroupStudentsSkippedStudentInfo> SkippedStudentInfos { get; init; }
}

public sealed record BulkAddGroupStudentsSkippedStudentInfo
{
    public required long StudentId { get; init; }
    public required BulkAddGroupStudentsSkipReason Reason { get; init; }
}

public enum BulkAddGroupStudentsSkipReason
{
    AlreadyInGroup = 1,
    NotFound = 2
}

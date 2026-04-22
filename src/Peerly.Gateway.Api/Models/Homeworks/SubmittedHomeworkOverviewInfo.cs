using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedHomeworkOverviewInfo
{
    public required long Id { get; init; }
    public required StudentInfo Student { get; init; }
    public required int ReviewCount { get; init; }
    public required int ReviewersMark { get; init; }
    public required bool HasDiscrepancy { get; init; }
    public required int? TeacherMark { get; init; }
}

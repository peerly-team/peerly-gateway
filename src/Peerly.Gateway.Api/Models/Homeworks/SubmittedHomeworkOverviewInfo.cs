using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedHomeworkOverviewInfo
{
    public required long Id { get; init; }
    public required StudentInfo Student { get; init; }
    public required int ReviewCount { get; init; }
    public int? ReviewersMark { get; init; }
    public bool? HasDiscrepancy { get; init; }
    public int? TeacherMark { get; init; }
}

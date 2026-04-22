using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;
using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Features.Homeworks.GetTeacherSubmittedHomework;

public sealed record GetTeacherSubmittedHomeworkQueryResponse
{
    public required SubmittedHomeworkInfo SubmittedHomework { get; init; }
    public required StudentInfo Student { get; init; }
    public required IReadOnlyList<TeacherSubmittedReviewInfo> SubmittedReviews { get; init; }
    public required int ReviewersMark { get; init; }
    public required int? TeacherMark { get; init; }
}

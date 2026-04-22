using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.GetSubmittedHomework;

public sealed record GetSubmittedHomeworkQueryResponse
{
    public required SubmittedHomeworkInfo SubmittedHomework { get; init; }
    public required IReadOnlyList<SubmittedReviewInfo> SubmittedReviews { get; init; }
    public int? FinalMark { get; init; }
}

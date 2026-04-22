using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.ListSubmittedHomeworkOverview;

public sealed record ListSubmittedHomeworkOverviewQueryResponse
{
    public required IReadOnlyCollection<SubmittedHomeworkOverviewInfo> SubmittedHomeworks { get; init; }
}

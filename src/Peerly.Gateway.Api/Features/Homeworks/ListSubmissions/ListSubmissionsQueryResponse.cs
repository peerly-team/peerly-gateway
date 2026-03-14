using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Submission;

namespace Peerly.Gateway.Api.Features.Homeworks.ListSubmissions;

public sealed record ListSubmissionsQueryResponse
{
    public required IReadOnlyCollection<Submission> Submissions { get; init; }
}

using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.ListAssignedReviews;

public sealed record ListAssignedReviewsQueryResponse
{
    public required IReadOnlyCollection<AssignedReviewInfo> AssignedReviews { get; init; }
}

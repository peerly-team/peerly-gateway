using MediatR;

namespace Peerly.Gateway.Api.Features.Homeworks.ListAssignedReviews;

public sealed record ListAssignedReviewsQuery : IRequest<ListAssignedReviewsQueryResponse>
{
    public required long HomeworkId { get; init; }
    public required long StudentId { get; init; }
}

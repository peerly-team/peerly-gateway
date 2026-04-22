using MediatR;

namespace Peerly.Gateway.Api.Features.Homeworks.GetAssignedReview;

public sealed record GetAssignedReviewQuery : IRequest<GetAssignedReviewQueryResponse>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
}

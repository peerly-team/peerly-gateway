using MediatR;

namespace Peerly.Gateway.Api.Features.Homeworks.GetSubmittedReview;

public sealed record GetSubmittedReviewQuery : IRequest<GetSubmittedReviewQueryResponse>
{
    public required long SubmittedReviewId { get; init; }
    public required long StudentId { get; init; }
}

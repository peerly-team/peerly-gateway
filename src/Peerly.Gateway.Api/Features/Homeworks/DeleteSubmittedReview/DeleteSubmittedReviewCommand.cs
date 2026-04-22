using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteSubmittedReview;

public sealed record DeleteSubmittedReviewCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedReviewId { get; init; }
    public required long StudentId { get; init; }
}

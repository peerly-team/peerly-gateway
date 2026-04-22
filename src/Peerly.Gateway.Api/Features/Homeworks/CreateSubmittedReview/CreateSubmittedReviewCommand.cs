using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedReview;

public sealed record CreateSubmittedReviewCommand : IRequest<Result<CreateSubmittedReviewCommandResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
    public required CreateSubmittedReviewRequestBody RequestBody { get; init; }
}

public sealed record CreateSubmittedReviewRequestBody
{
    public required int Mark { get; init; }
    public required string Comment { get; init; }
}

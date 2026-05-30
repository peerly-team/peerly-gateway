using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Submissions.CreateSubmittedReview;

public sealed record CreateSubmittedReviewCommand : IRequest<Result<CreateSubmittedReviewCommandResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
    public required CreateSubmittedReviewRequestBody RequestBody { get; init; }
}

public sealed record CreateSubmittedReviewRequestBody
{
    public required IReadOnlyList<SubmittedReviewScoreInput> Scores { get; init; }
    public required string Comment { get; init; }
}

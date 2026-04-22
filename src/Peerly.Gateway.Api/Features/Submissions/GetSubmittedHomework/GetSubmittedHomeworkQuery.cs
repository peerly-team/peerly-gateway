using MediatR;

namespace Peerly.Gateway.Api.Features.Submissions.GetSubmittedHomework;

public sealed record GetSubmittedHomeworkQuery : IRequest<GetSubmittedHomeworkQueryResponse>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
}

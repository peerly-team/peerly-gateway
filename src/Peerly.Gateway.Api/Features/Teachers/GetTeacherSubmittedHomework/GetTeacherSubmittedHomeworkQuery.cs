using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherSubmittedHomework;

public sealed record GetTeacherSubmittedHomeworkQuery : IRequest<GetTeacherSubmittedHomeworkQueryResponse>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long TeacherId { get; init; }
}

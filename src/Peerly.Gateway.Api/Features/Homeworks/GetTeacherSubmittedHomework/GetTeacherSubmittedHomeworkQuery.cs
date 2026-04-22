using MediatR;

namespace Peerly.Gateway.Api.Features.Homeworks.GetTeacherSubmittedHomework;

public sealed record GetTeacherSubmittedHomeworkQuery : IRequest<GetTeacherSubmittedHomeworkQueryResponse>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long TeacherId { get; init; }
}

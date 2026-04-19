using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherHomework;

public sealed record GetTeacherHomeworkQuery : IRequest<GetTeacherHomeworkQueryResponse>
{
    public required long TeacherId { get; init; }
    public required long HomeworkId { get; init; }
}

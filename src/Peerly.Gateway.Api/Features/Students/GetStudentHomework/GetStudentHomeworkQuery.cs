using MediatR;

namespace Peerly.Gateway.Api.Features.Students.GetStudentHomework;

public sealed record GetStudentHomeworkQuery : IRequest<GetStudentHomeworkQueryResponse>
{
    public required long StudentId { get; init; }
    public required long HomeworkId { get; init; }
}

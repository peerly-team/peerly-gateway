using MediatR;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseHomeworks;

public sealed record ListStudentCourseHomeworksQuery : IRequest<ListStudentCourseHomeworksQueryResponse>
{
    public required long StudentId { get; init; }
    public required long CourseId { get; init; }
}

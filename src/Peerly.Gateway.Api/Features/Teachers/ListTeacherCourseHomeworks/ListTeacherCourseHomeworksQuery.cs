using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseHomeworks;

public sealed record ListTeacherCourseHomeworksQuery : IRequest<ListTeacherCourseHomeworksQueryResponse>
{
    public required long TeacherId { get; init; }
    public required long CourseId { get; init; }
}

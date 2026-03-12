using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;

public sealed record GetTeacherCourseQuery : IRequest<GetTeacherCourseQueryResponse>
{
    public required long TeacherId { get; init; }
    public required long CourseId { get; init; }
}

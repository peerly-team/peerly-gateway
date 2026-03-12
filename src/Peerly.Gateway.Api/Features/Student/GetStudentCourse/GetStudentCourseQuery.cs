using MediatR;

namespace Peerly.Gateway.Api.Features.Student.GetStudentCourse;

public sealed record GetStudentCourseQuery : IRequest<GetStudentCourseQueryResponse>
{
    public required long StudentId { get; init; }
    public required long CourseId { get; init; }
}

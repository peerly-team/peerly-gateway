using MediatR;

namespace Peerly.Gateway.Api.Features.Students.GetStudentCourse;

public sealed record GetStudentCourseQuery : IRequest<GetStudentCourseQueryResponse>
{
    public required long StudentId { get; init; }
    public required long CourseId { get; init; }
}

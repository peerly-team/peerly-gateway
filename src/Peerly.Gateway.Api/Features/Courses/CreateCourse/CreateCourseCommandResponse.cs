namespace Peerly.Gateway.Api.Features.Courses.CreateCourse;

public sealed record CreateCourseCommandResponse
{
    public required long CourseId { get; init; }
}

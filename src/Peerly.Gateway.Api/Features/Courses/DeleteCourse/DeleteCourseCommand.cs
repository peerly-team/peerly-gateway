namespace Peerly.Gateway.Api.Features.Courses.DeleteCourse;

public sealed record DeleteCourseCommand
{
    public required long UserId { get; init; }
    public required DeleteCourseRequestBody RequestBody { get; init; }
}

public sealed record DeleteCourseRequestBody
{
    public required long CourseId { get; init; }
}

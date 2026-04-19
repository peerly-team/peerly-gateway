namespace Peerly.Gateway.Api.Features.Courses.CreateCourseHomework;

public sealed record CreateCourseHomeworkCommandResponse
{
    public required long HomeworkId { get; init; }
}

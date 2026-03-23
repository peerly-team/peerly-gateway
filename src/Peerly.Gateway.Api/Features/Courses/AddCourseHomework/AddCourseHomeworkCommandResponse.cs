namespace Peerly.Gateway.Api.Features.Courses.AddCourseHomework;

public sealed record AddCourseHomeworkCommandResponse
{
    public required long HomeworkId { get; init; }
}

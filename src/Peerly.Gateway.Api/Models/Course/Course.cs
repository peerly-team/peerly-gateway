namespace Peerly.Gateway.Api.Models.Course;

public sealed record Course
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required CourseStatus Status { get; init; }
    public required long StudentCount { get; init; }
    public required long HomeworkCount { get; init; }
}

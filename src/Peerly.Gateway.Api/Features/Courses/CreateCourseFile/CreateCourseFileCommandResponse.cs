namespace Peerly.Gateway.Api.Features.Courses.CreateCourseFile;

public sealed record CreateCourseFileCommandResponse
{
    public required long FileId { get; init; }
}

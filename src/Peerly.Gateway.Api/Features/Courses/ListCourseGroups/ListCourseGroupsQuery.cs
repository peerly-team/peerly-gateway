namespace Peerly.Gateway.Api.Features.Courses.ListCourseGroups;

public sealed record ListCourseGroupsQuery
{
    public required long CourseId { get; init; }
}

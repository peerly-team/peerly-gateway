using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses.GetCourse;

public sealed record GetCourseQueryResponse
{
    public required CourseInfo CourseInfo { get; init; }
}

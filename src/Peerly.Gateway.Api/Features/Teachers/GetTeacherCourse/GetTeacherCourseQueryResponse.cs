using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;

public sealed record GetTeacherCourseQueryResponse
{
    public required CourseInfo CourseInfo { get; init; }
}

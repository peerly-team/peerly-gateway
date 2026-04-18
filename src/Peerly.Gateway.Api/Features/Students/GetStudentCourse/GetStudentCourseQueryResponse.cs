using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Students.GetStudentCourse;

public sealed record GetStudentCourseQueryResponse
{
    public required CourseInfo CourseInfo { get; init; }
}

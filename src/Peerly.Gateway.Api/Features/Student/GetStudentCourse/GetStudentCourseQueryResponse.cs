using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Student.GetStudentCourse;

public sealed record GetStudentCourseQueryResponse
{
    public required CourseInfo CourseInfo { get; init; }
}

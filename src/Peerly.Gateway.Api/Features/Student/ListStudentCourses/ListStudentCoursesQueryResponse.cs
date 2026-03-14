using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Student.ListStudentCourses;

public sealed record ListStudentCoursesQueryResponse
{
    public required IReadOnlyCollection<CourseInfo> CourseInfos { get; init; }
}

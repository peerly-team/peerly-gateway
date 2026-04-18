using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourses;

public sealed record ListStudentCoursesQueryResponse
{
    public required IReadOnlyCollection<CourseInfo> CourseInfos { get; init; }
}

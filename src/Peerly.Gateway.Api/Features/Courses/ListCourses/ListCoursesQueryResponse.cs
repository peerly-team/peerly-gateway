using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses.ListCourses;

public sealed record ListCoursesQueryResponse
{
    public required IReadOnlyCollection<CourseInfo> CourseInfos { get; init; }
}

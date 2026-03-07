using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourses;

public sealed class ListTeacherCoursesQueryResponse
{
    public required IReadOnlyCollection<CourseInfo> CourseInfos { get; init; }
}

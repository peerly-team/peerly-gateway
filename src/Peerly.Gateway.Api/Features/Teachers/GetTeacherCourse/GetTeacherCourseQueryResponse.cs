using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Course;
using Peerly.Gateway.Api.Models.Files;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;

public sealed record GetTeacherCourseQueryResponse
{
    public required CourseInfo CourseInfo { get; init; }
    public required long StudentCount { get; init; }
    public required long HomeworkCount { get; init; }
    public required IReadOnlyCollection<File> Files { get; init; }
}

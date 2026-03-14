using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourses;

public sealed record ListTeacherCoursesQuery : IRequest<ListTeacherCoursesQueryResponse>
{
    public required long TeacherId { get; init; }
    public required ListTeacherCoursesFilter Filter { get; init; }
    public required PaginationInfo PaginationInfo { get; init; }
}

public sealed record ListTeacherCoursesFilter
{
    public IReadOnlyList<CourseStatus> CourseStatuses { get; init; } = new List<CourseStatus>();
}

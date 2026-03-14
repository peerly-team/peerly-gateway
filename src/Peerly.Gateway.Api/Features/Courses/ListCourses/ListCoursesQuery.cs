using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses.ListCourses;

public sealed record ListCoursesQuery : IRequest<ListCoursesQueryResponse>
{
    public required ListCoursesFilter Filter { get; init; }
    public required PaginationInfo PaginationInfo { get; init; }
}

public sealed record ListCoursesFilter
{
    public IReadOnlyList<CourseStatus> CourseStatuses { get; init; } = new List<CourseStatus>();
}

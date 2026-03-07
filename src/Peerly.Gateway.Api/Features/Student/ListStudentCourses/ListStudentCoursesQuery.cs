using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Student.ListStudentCourses;

public sealed record ListStudentCoursesQuery : IRequest<ListStudentCoursesQueryResponse>
{
    public required long StudentId { get; init; }
    public required ListStudentCoursesFilter Filter { get; init; }
    public required PaginationInfo PaginationInfo { get; init; }
}

public sealed record ListStudentCoursesFilter
{
    public IReadOnlyList<CourseStatus> CourseStatuses { get; init; } = new List<CourseStatus>();
}

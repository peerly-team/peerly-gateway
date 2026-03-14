using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Student.ListStudentCourseHomeworks;

public sealed record ListStudentCourseHomeworksQuery : IRequest<ListStudentCourseHomeworksQueryResponse>
{
    public required long CourseId { get; init; }
    public required long StudentId { get; init; }
    public required ListStudentCourseHomeworksFilter Filter { get; init; }
}

public sealed record ListStudentCourseHomeworksFilter
{
    public IReadOnlyList<HomeworkStatus> HomeworkStatuses { get; init; } = new List<HomeworkStatus>();
}

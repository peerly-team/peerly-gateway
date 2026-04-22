using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseHomeworks;

public sealed record ListCourseHomeworksQuery : IRequest<ListCourseHomeworksQueryResponse>
{
    public required long CourseId { get; init; }
    public required long UserId { get; init; }
    public required Role Role { get; init; }
    public required ListCourseHomeworksFilter Filter { get; init; }
}

public sealed record ListCourseHomeworksFilter
{
    public IReadOnlyList<HomeworkStatus> HomeworkStatuses { get; init; } = new List<HomeworkStatus>();
}

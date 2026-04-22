using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseGroups;

public sealed record ListTeacherCourseGroupsQuery : IRequest<ListTeacherCourseGroupsQueryResponse>
{
    public required long TeacherId { get; init; }
    public required long CourseId { get; init; }
}

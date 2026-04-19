using MediatR;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseGroups;

public sealed record ListStudentCourseGroupsQuery : IRequest<ListStudentCourseGroupsQueryResponse>
{
    public required long StudentId { get; init; }
    public required long CourseId { get; init; }
}

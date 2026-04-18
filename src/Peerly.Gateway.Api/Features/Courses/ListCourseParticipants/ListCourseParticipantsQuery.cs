using MediatR;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;

public sealed record ListCourseParticipantsQuery : IRequest<ListCourseParticipantsQueryResponse>
{
    public required long CourseId { get; init; }
}

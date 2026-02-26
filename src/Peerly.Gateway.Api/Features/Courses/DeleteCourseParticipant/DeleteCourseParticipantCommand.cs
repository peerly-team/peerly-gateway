using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.DeleteCourseParticipant;

public sealed record DeleteCourseParticipantCommand : IRequest<Result<EmptyResponse>>
{
    public required long CourseId { get; init; }
    public required DeleteCourseParticipantRequestBody RequestBody { get; init; }
}

public sealed record DeleteCourseParticipantRequestBody
{
    public required long ParticipantId { get; init; }
}

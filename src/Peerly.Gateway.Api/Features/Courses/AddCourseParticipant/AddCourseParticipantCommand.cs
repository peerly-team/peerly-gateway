using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.AddCourseParticipant;

public sealed record AddCourseParticipantCommand : IRequest<Result<EmptyResponse>>
{
    public required long CourseId { get; init; }
    public required AddCourseParticipantRequestBody RequestBody { get; init; }
}

public sealed record AddCourseParticipantRequestBody
{
    public required long UserId { get; init; }
}

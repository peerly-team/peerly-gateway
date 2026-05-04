using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.PublishCourse;

public sealed record PublishCourseCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long CourseId { get; init; }
}

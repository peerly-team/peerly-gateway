using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses.UpdateCourse;

public sealed record UpdateCourseCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long CourseId { get; init; }
    public required UpdateCourseRequestBody RequestBody { get; init; }
}

public sealed record UpdateCourseRequestBody
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required CourseStatus Status { get; init; }
}

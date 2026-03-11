using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.DeleteCourse;

public sealed record DeleteCourseCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required DeleteCourseRequestBody RequestBody { get; init; }
}

public sealed record DeleteCourseRequestBody
{
    public required long CourseId { get; init; }
}

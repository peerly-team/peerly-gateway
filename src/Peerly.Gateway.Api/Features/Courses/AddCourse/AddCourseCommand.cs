using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.AddCourse;

public sealed record AddCourseCommand : IRequest<Result<EmptyResponse>>
{
    public required long UserId { get; init; }
    public required AddCourseRequestBody RequestBody { get; init; }
}

public sealed record AddCourseRequestBody
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}

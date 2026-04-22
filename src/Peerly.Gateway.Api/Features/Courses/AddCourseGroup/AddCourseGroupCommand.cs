using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.AddCourseGroup;

public sealed record AddCourseGroupCommand : IRequest<Result<EmptyResponse>>
{
    public required long CourseId { get; init; }
    public required AddCourseGroupRequestBody RequestBody { get; init; }
}

public sealed record AddCourseGroupRequestBody
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourse;

public sealed record CreateCourseCommand : IRequest<Result<CreateCourseCommandResponse>>
{
    public required long TeacherId { get; init; }
    public required CreateCourseRequestBody RequestBody { get; init; }
}

public sealed record CreateCourseRequestBody
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}

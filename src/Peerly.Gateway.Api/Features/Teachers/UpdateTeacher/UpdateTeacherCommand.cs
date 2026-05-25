using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Teachers.UpdateTeacher;

public sealed record UpdateTeacherCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required UpdateTeacherRequestBody RequestBody { get; init; }
}

public sealed record UpdateTeacherRequestBody
{
    public required string Name { get; init; }
}

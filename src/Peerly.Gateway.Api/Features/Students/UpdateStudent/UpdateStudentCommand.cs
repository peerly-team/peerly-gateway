using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Students.UpdateStudent;

public sealed record UpdateStudentCommand : IRequest<Result<EmptyResponse>>
{
    public required long StudentId { get; init; }
    public required UpdateStudentRequestBody RequestBody { get; init; }
}

public sealed record UpdateStudentRequestBody
{
    public required string Name { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupStudent;

public sealed record AddGroupStudentCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long GroupId { get; init; }
    public required AddGroupStudentRequestBody RequestBody { get; init; }
}

public sealed record AddGroupStudentRequestBody
{
    public required long StudentId { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupTeacher;

public sealed record AddGroupTeacherCommand : IRequest<Result<EmptyResponse>>
{
    public required long GroupId { get; init; }
    public required long ActorTeacherId { get; init; }
    public required AddGroupTeacherRequestBody RequestBody { get; init; }
}

public sealed record AddGroupTeacherRequestBody
{
    public required long TeacherId { get; init; }
}

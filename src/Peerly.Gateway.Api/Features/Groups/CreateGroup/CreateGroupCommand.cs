using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.CreateGroup;

public sealed record CreateGroupCommand : IRequest<Result<CreateGroupCommandResponse>>
{
    public required long TeacherId { get; init; }
    public required CreateGroupRequestBody RequestBody { get; init; }
}

public sealed record CreateGroupRequestBody
{
    public required long CourseId { get; init; }
    public required string Name { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.UpdateGroup;

public sealed record UpdateGroupCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long GroupId { get; init; }
    public required UpdateGroupRequestBody RequestBody { get; init; }
}

public sealed record UpdateGroupRequestBody
{
    public required string Name { get; init; }
}

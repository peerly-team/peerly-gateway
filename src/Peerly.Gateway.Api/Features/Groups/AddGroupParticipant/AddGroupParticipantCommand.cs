using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupParticipant;

public sealed record AddGroupParticipantCommand : IRequest<Result<EmptyResponse>>
{
    public required long GroupId { get; init; }
    public required AddGroupParticipantRequestBody RequestBody { get; init; }
}

public sealed record AddGroupParticipantRequestBody
{
    public required long UserId { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.DeleteGroupParticipant;

public sealed record DeleteGroupParticipantCommand : IRequest<Result<EmptyResponse>>
{
    public required long GroupId { get; init; }
    public required DeleteGroupParticipantRequestBody RequestBody { get; init; }
}

public sealed record DeleteGroupParticipantRequestBody
{
    public required long ParticipantId { get; init; }
}

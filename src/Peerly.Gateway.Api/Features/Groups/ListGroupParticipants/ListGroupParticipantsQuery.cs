using MediatR;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;

public sealed record ListGroupParticipantsQuery : IRequest<ListGroupParticipantsQueryResponse>
{
    public required long GroupId { get; init; }
}

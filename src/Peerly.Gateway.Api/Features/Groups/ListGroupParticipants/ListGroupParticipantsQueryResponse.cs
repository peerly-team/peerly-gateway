using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Users;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;

public sealed record ListGroupParticipantsQueryResponse
{
    public required IReadOnlyCollection<User> Participants { get; init; }
}

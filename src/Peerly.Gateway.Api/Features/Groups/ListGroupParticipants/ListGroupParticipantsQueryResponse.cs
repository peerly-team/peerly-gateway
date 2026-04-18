using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;

public sealed record ListGroupParticipantsQueryResponse
{
    public required IReadOnlyCollection<TeacherInfo> Teachers { get; init; }
    public required IReadOnlyCollection<StudentInfo> Students { get; init; }
}

using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Users;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;

public sealed record ListCourseParticipantsQueryResponse
{
    public required IReadOnlyCollection<User> Participants { get; init; }
}

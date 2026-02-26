using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Groups.GetGroup;

public sealed record GetGroupQueryResponse
{
    public required Group Group { get; init; }
}

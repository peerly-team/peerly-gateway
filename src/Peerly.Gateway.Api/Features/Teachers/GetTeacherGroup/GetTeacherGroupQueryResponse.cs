using Peerly.Gateway.Api.Models.Group;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherGroup;

public sealed record GetTeacherGroupQueryResponse
{
    public required GroupInfo GroupInfo { get; init; }
}

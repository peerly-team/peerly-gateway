namespace Peerly.Gateway.Api.Features.Me.GetRole;

public sealed record GetMyRoleResponse
{
    public required string Role { get; init; }
}

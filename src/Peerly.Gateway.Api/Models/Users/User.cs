using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Models.Users;

public sealed record User
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required Role Role { get; init; }
}

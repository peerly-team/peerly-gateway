namespace Peerly.Gateway.Api.Features.Groups.CreateGroup;

public sealed record CreateGroupCommandResponse
{
    public required long GroupId { get; init; }
}

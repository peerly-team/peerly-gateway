namespace Peerly.Gateway.Api.Models.Group;

public sealed record GroupInfo
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required long StudentCount { get; init; }
}

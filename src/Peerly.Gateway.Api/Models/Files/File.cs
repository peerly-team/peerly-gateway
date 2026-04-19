namespace Peerly.Gateway.Api.Models.Files;

public sealed record File
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required long Size { get; init; }
}

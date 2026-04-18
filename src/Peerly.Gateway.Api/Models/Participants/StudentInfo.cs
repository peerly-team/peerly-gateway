namespace Peerly.Gateway.Api.Models.Participants;

public sealed record StudentInfo
{
    public required long StudentId { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
}

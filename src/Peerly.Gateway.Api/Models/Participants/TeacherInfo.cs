namespace Peerly.Gateway.Api.Models.Participants;

public sealed record TeacherInfo
{
    public required long TeacherId { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
}

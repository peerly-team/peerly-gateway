namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomework;

public sealed record CreateSubmittedHomeworkCommandResponse
{
    public required long SubmittedHomeworkId { get; init; }
}

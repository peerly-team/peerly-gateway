namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomeworkFile;

public sealed record CreateSubmittedHomeworkFileCommandResponse
{
    public required long FileId { get; init; }
}

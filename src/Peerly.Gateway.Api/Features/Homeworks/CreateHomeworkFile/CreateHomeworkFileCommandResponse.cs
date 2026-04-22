namespace Peerly.Gateway.Api.Features.Homeworks.CreateHomeworkFile;

public sealed record CreateHomeworkFileCommandResponse
{
    public required long FileId { get; init; }
}

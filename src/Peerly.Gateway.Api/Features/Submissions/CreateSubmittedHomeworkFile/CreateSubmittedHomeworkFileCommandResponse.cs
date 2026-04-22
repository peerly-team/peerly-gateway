namespace Peerly.Gateway.Api.Features.Submissions.CreateSubmittedHomeworkFile;

public sealed record CreateSubmittedHomeworkFileCommandResponse
{
    public required long FileId { get; init; }
}

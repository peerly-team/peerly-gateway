namespace Peerly.Gateway.Api.Features.Groups.CreateGroupHomework;

public sealed record CreateGroupHomeworkCommandResponse
{
    public required long HomeworkId { get; init; }
}

namespace Peerly.Gateway.Api.Features.Groups.DeleteGroup;

public sealed record DeleteGroupCommand
{
    public required long UserId { get; init; }
    public required DeleteGroupRequestBody RequestBody { get; init; }
}

public sealed record DeleteGroupRequestBody
{
    public required long GroupId { get; init; }
}

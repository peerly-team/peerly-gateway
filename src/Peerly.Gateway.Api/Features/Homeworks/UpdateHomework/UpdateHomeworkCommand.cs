using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateHomework;

public sealed record UpdateHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long HomeworkId { get; init; }
    public required long UserId { get; init; }
    public required UpdateHomeworkRequestBody RequestBody { get; init; }
}

public sealed record UpdateHomeworkRequestBody
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int? AmountOfReviews { get; init; }
    public string? Checklist { get; init; }
    public DateTimeOffset? Deadline { get; init; }
    public DateTimeOffset? ReviewDeadline { get; init; }
}

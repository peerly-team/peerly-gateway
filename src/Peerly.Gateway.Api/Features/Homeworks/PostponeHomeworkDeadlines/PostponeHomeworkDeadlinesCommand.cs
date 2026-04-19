using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.PostponeHomeworkDeadlines;

public sealed record PostponeHomeworkDeadlinesCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long HomeworkId { get; init; }
    public required PostponeHomeworkDeadlinesRequestBody RequestBody { get; init; }
}

public sealed record PostponeHomeworkDeadlinesRequestBody
{
    public DateTimeOffset? Deadline { get; init; }
    public DateTimeOffset? ReviewDeadline { get; init; }
}

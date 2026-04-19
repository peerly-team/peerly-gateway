using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateDraftHomework;

public sealed record UpdateDraftHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long HomeworkId { get; init; }
    public required UpdateDraftHomeworkRequestBody RequestBody { get; init; }
}

public sealed record UpdateDraftHomeworkRequestBody
{
    public required string Name { get; init; }
    public required int AmountOfReviewers { get; init; }
    public string? Description { get; init; }
    public required string Checklist { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required DateTimeOffset ReviewDeadline { get; init; }
    public required int DiscrepancyThreshold { get; init; }
}

using System;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record HomeworkInfo
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required HomeworkStatus Status { get; init; }
    public required string Checklist { get; init; }
    public string? Description { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required DateTimeOffset ReviewDeadline { get; init; }
    public required int AmountOfReviewers { get; init; }
    public required int DiscrepancyThreshold { get; init; }
}

using System;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record Homework
{
    public required string Name { get; init; }
    public required HomeworkStatus Status { get; init; }
    public required string Description { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required int AmountOfReviews { get; init; }
}

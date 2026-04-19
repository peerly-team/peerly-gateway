using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.CreateGroupHomework;

public sealed record CreateGroupHomeworkCommand : IRequest<Result<CreateGroupHomeworkCommandResponse>>
{
    public required long TeacherId { get; init; }
    public required long GroupId { get; init; }
    public required CreateGroupHomeworkRequestBody RequestBody { get; init; }
}

public sealed record CreateGroupHomeworkRequestBody
{
    public required string Name { get; init; }
    public required int AmountOfReviewers { get; init; }
    public string? Description { get; init; }
    public required string Checklist { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required DateTimeOffset ReviewDeadline { get; init; }
    public required int DiscrepancyThreshold { get; init; }
}

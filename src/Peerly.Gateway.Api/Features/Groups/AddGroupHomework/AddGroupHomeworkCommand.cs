using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupHomework;

public sealed record AddGroupHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long GroupId { get; init; }
    public required long UserId { get; init; }
    public required AddGroupHomeworkRequestBody RequestBody { get; init; }
}

public sealed record AddGroupHomeworkRequestBody
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required int AmountOfReviews { get; init; }
    public required string Checklist { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required DateTimeOffset ReviewDeadline { get; init; }
}

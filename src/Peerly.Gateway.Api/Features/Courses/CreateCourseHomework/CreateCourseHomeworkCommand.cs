using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourseHomework;

public sealed record CreateCourseHomeworkCommand : IRequest<Result<CreateCourseHomeworkCommandResponse>>
{
    public required long TeacherId { get; init; }
    public required long CourseId { get; init; }
    public required CreateCourseHomeworkRequestBody RequestBody { get; init; }
}

public sealed record CreateCourseHomeworkRequestBody
{
    public required string Name { get; init; }
    public required int AmountOfReviewers { get; init; }
    public string? Description { get; init; }
    public required string Checklist { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required DateTimeOffset ReviewDeadline { get; init; }
    public required int DiscrepancyThreshold { get; init; }
}

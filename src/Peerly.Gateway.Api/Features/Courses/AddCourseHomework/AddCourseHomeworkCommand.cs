using System;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.AddCourseHomework;

public sealed record AddCourseHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long CourseId { get; init; }
    public required long TeacherId { get; init; }
    public required AddCourseHomeworkRequestBody RequestBody { get; init; }
}

public sealed record AddCourseHomeworkRequestBody
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required int AmountOfReviews { get; init; }
    public required string Checklist { get; init; }
    public required DateTimeOffset Deadline { get; init; }
    public required DateTimeOffset ReviewDeadline { get; init; }
}

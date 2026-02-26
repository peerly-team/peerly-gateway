using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.DeleteCourseHomework;

public sealed record DeleteCourseHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long UserId { get; init; }
    public required long CourseId { get; init; }
    public required long HomeworkId { get; init; }
}

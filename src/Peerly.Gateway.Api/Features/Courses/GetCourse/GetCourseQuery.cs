using MediatR;

namespace Peerly.Gateway.Api.Features.Courses.GetCourse;

public sealed record GetCourseQuery : IRequest<GetCourseQueryResponse>
{
    public required long CourseId { get; init; }
}

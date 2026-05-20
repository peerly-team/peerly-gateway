using MediatR;
using Peerly.Gateway.Api.Models.Course;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Teachers.SearchTeacherHomeworks;

public sealed record SearchTeacherHomeworksQuery : IRequest<SearchTeacherHomeworksQueryResponse>
{
    public required long TeacherId { get; init; }
    public required SearchHomeworksFilter Filter { get; init; }
    public required PaginationInfo PaginationInfo { get; init; }
}

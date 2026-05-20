using MediatR;
using Peerly.Gateway.Api.Models.Course;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Students.SearchStudentHomeworks;

public sealed record SearchStudentHomeworksQuery : IRequest<SearchStudentHomeworksQueryResponse>
{
    public required long StudentId { get; init; }
    public required SearchHomeworksFilter Filter { get; init; }
    public required PaginationInfo PaginationInfo { get; init; }
}

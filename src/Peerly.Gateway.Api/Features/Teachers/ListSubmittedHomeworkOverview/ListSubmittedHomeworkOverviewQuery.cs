using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.ListSubmittedHomeworkOverview;

public sealed record ListSubmittedHomeworkOverviewQuery : IRequest<ListSubmittedHomeworkOverviewQueryResponse>
{
    public required long HomeworkId { get; init; }
    public required long TeacherId { get; init; }
}

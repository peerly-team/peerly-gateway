using MediatR;

namespace Peerly.Gateway.Api.Features.Homeworks.GetHomework;

public sealed record GetHomeworkQuery : IRequest<GetHomeworkQueryResponse>
{
    public required long HomeworkId { get; init; }
}

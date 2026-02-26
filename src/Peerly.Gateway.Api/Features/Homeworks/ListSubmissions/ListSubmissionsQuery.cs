using MediatR;

namespace Peerly.Gateway.Api.Features.Homeworks.ListSubmissions;

public sealed record ListSubmissionsQuery : IRequest<ListSubmissionsQueryResponse>
{
    public required long HomeworkId { get; init; }
    public required long UserId { get; init; }
}

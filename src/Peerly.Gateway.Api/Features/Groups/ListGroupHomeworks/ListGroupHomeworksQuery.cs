using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupHomeworks;

public sealed record ListGroupHomeworksQuery : IRequest<ListGroupHomeworksQueryResponse>
{
    public required long GroupId { get; init; }
    public required long UserId { get; init; }
    public required Role Role { get; init; }
    public required ListGroupHomeworksFilter Filter { get; init; }
}

public sealed record ListGroupHomeworksFilter
{
    public IReadOnlyList<HomeworkStatus> HomeworkStatuses { get; init; } = new List<HomeworkStatus>();
}

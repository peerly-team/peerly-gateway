using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupHomeworks;

public sealed record ListGroupHomeworksQueryResponse
{
    public required IReadOnlyCollection<Homework> Homeworks { get; init; }
}

using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.GetHomework;

public sealed record GetHomeworkQueryResponse
{
    public required Homework Homework { get; init; }
}

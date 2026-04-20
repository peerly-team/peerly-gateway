using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.GetSubmittedHomework;

public sealed record GetSubmittedHomeworkQueryResponse
{
    public required SubmittedHomeworkDetail Submission { get; init; }
}

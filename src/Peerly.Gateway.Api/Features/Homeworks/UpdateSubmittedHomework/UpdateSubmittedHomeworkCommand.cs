using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateSubmittedHomework;

public sealed record UpdateSubmittedHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
    public required UpdateSubmittedHomeworkRequestBody RequestBody { get; init; }
}

public sealed record UpdateSubmittedHomeworkRequestBody
{
    public required string Comment { get; init; }
}

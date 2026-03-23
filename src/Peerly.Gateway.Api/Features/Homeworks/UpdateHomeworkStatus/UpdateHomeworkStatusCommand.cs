using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateHomeworkStatus;

public sealed record UpdateHomeworkStatusCommand : IRequest<Result<EmptyResponse>>
{
    public required long HomeworkId { get; init; }
    public required long TeacherId { get; init; }
    public required UpdateHomeworkStatusRequestBody RequestBody { get; init; }
}

public sealed record UpdateHomeworkStatusRequestBody
{
    public HomeworkStatus HomeworkStatus { get; init; }
}

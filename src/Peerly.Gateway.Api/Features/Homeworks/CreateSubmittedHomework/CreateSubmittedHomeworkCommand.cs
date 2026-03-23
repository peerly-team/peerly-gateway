using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomework;

public sealed record CreateSubmittedHomeworkCommand : IRequest<Result<CreateSubmittedHomeworkCommandResponse>>
{
    public required long HomeworkId { get; init; }
    public required long StudentId { get; init; }
    public required CreateSubmittedHomeworkRequestBody RequestBody { get; init; }
}

public sealed record CreateSubmittedHomeworkRequestBody
{
    public required string Comment { get; init; }
}

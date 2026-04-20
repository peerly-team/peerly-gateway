using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteSubmittedHomeworkFile;

public sealed record DeleteSubmittedHomeworkFileCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long FileId { get; init; }
    public required long StudentId { get; init; }
}

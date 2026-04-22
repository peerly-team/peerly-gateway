using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteHomeworkFile;

public sealed record DeleteHomeworkFileCommand : IRequest<Result<EmptyResponse>>
{
    public required long HomeworkId { get; init; }
    public required long FileId { get; init; }
    public required long TeacherId { get; init; }
}

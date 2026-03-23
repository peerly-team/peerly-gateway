using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateHomeworkFile;

public sealed record CreateHomeworkFileCommand : IRequest<Result<CreateHomeworkFileCommandResponse>>
{
    public required long HomeworkId { get; init; }
    public required long TeacherId { get; init; }
    public required CreateHomeworkFileRequestBody RequestBody { get; init; }
}

public sealed record CreateHomeworkFileRequestBody
{
    public required string StorageId { get; init; }
    public required string FileName { get; init; }
    public required int FileSize { get; init; }
}

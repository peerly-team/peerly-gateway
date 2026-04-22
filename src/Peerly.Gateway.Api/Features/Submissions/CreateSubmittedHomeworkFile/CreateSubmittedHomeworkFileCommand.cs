using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.CreateSubmittedHomeworkFile;

public sealed record CreateSubmittedHomeworkFileCommand : IRequest<Result<CreateSubmittedHomeworkFileCommandResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
    public required CreateSubmittedHomeworkFileRequestBody RequestBody { get; init; }
}

public sealed record CreateSubmittedHomeworkFileRequestBody
{
    public required string StorageId { get; init; }
    public required string FileName { get; init; }
    public required int FileSize { get; init; }
}

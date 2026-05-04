using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourseFile;

public sealed record CreateCourseFileCommand : IRequest<Result<CreateCourseFileCommandResponse>>
{
    public required long CourseId { get; init; }
    public required long TeacherId { get; init; }
    public required CreateCourseFileRequestBody RequestBody { get; init; }
}

public sealed record CreateCourseFileRequestBody
{
    public required string StorageId { get; init; }
    public required string FileName { get; init; }
    public required int FileSize { get; init; }
}

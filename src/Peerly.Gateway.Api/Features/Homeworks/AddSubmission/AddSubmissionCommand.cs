using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Files;

namespace Peerly.Gateway.Api.Features.Homeworks.AddSubmission;

public sealed record AddSubmissionCommand : IRequest<Result<EmptyResponse>>
{
    public required long HomeworkId { get; init; }
    public required long UserId { get; init; }
    public required AddSubmissionRequestBody RequestBody { get; init; }
}

public sealed record AddSubmissionRequestBody
{
    public string? Comment { get; init; }
    public required IReadOnlyCollection<File> Files { get; init; }
}

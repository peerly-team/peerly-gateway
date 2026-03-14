using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Files;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateSubmission;

public sealed record UpdateSubmissionCommand : IRequest<Result<EmptyResponse>>
{
    public required long HomeworkId { get; init; }
    public required long UserId { get; init; }
    public required UpdateSubmissionRequestBody RequestBody { get; init; }
}

public sealed record UpdateSubmissionRequestBody
{
    public required short? Mark { get; init; }
    public required string? Comment { get; init; }
    public required IReadOnlyCollection<File>? Files { get; init; }
}

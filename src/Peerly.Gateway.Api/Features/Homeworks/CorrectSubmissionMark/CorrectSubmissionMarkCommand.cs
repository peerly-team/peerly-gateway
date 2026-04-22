using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CorrectSubmissionMark;

public sealed record CorrectSubmissionMarkCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long TeacherId { get; init; }
    public required CorrectSubmissionMarkRequestBody RequestBody { get; init; }
}

public sealed record CorrectSubmissionMarkRequestBody
{
    public required int TeacherMark { get; init; }
}

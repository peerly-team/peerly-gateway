using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.CorrectSubmittedHomeworkMark;

public sealed record CorrectSubmittedHomeworkMarkCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long TeacherId { get; init; }
    public required CorrectSubmittedHomeworkMarkRequestBody RequestBody { get; init; }
}

public sealed record CorrectSubmittedHomeworkMarkRequestBody
{
    public required int TeacherMark { get; init; }
}

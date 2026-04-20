using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteSubmittedHomework;

public sealed record DeleteSubmittedHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long SubmittedHomeworkId { get; init; }
    public required long StudentId { get; init; }
}

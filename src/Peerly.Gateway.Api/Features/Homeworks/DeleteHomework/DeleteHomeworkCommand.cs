using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteHomework;

public sealed record DeleteHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long HomeworkId { get; init; }
}

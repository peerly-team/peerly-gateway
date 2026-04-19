using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.PublishHomework;

public sealed record PublishHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long HomeworkId { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.DeleteGroupHomework;

public sealed record DeleteGroupHomeworkCommand : IRequest<Result<EmptyResponse>>
{
    public required long UserId { get; init; }
    public required long GroupId { get; init; }
    public required long HomeworkId { get; init; }
}

using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.DeleteGroup;

public sealed record DeleteGroupCommand : IRequest<Result<EmptyResponse>>
{
    public required long TeacherId { get; init; }
    public required long GroupId { get; init; }
}

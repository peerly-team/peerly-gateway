using MediatR;

namespace Peerly.Gateway.Api.Features.Groups.GetGroup;

public sealed record GetGroupQuery : IRequest<GetGroupQueryResponse>
{
    public required long GroupId { get; init; }
}

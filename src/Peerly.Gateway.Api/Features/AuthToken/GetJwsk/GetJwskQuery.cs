using MediatR;

namespace Peerly.Gateway.Api.Features.AuthToken.GetJwsk;

public sealed record GetJwksQuery : IRequest<GetJwksQueryResponse>
{
    public required string Issuer { get; init; }
}

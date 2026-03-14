using MediatR;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks.Models;

public class GetJwksQuery : IRequest<GetJwksQueryResponse>
{
    public required string Issuer { get; init; }
}

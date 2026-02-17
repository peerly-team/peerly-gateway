using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Features;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks.Models;

public sealed class GetJwksHandler : FeatureHandlerAdapter<GetJwksQuery, GetJwksQueryResponse, V1GetJwksRequest, V1GetJwksResponse>
{
    public GetJwksHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1GetJwksAsync, mapper)
    {
    }
}

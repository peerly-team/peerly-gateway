using AutoMapper;
using Peerly.Auth.V1;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks.Models;

internal sealed class GetJwksProfile : Profile
{
    public GetJwksProfile()
    {
        CreateMap<GetJwksQuery, V1GetJwksRequest>();
        CreateMap<V1GetJwksResponse, GetJwksQueryResponse>();
    }
}

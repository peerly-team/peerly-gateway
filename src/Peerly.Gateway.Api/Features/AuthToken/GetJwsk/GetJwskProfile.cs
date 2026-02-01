using AutoMapper;
using Peerly.Auth.V1;

namespace Peerly.Gateway.Api.Features.AuthToken.GetJwsk;

public sealed class GetJwksProfile : Profile
{
    public GetJwksProfile()
    {
        CreateMap<GetJwksQuery, V1GetJwksRequest>();
        CreateMap<V1GetJwksResponse, GetJwksQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions.RefreshAccessToken;

public sealed class RefreshAccessTokenProfile : Profile
{
    public RefreshAccessTokenProfile()
    {
        CreateMap<RefreshCommand, V1RefreshRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<RefreshRequestBody, V1RefreshRequest>();
        CreateMap<V1RefreshResponse, Result<RefreshCommandResponse>>();
        CreateMap<V1RefreshResponse.Types.Success, RefreshCommandResponse>();
    }
}

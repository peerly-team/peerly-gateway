using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Refresh;

public sealed class RefreshProfile : Profile
{
    public RefreshProfile()
    {
        CreateMap<RefreshCommand, V1RefreshRequest>();
        CreateMap<V1RefreshResponse, Result<RefreshCommandResponse>>();
        CreateMap<V1RefreshResponse.Types.Success, RefreshCommandResponse>();
    }
}

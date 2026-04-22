using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Login;

public sealed class LoginProfile : Profile
{
    public LoginProfile()
    {
        CreateMap<LoginCommand, V1LoginRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<LoginRequestBody, V1LoginRequest>();
        CreateMap<V1LoginResponse, Result<LoginCommandResponse>>();
        CreateMap<V1LoginResponse.Types.Success, LoginCommandResponse>(MemberList.Source);
    }
}

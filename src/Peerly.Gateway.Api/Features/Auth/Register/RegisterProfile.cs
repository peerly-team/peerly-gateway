using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Register;

public sealed class RegisterProfile : Profile
{
    public RegisterProfile()
    {
        CreateMap<RegisterCommand, V1RegisterRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<RegisterRequestBody, V1RegisterRequest>();
        CreateMap<V1RegisterResponse, Result<RegisterCommandResponse>>();
        CreateMap<V1RegisterResponse.Types.Success, RegisterCommandResponse>(MemberList.Source);
    }
}

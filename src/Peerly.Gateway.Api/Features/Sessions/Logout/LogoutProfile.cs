using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions.Logout;

public sealed class LogoutProfile : Profile
{
    public LogoutProfile()
    {
        CreateMap<LogoutQuery, V1LogoutRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<LogoutRequestBody, V1LogoutRequest>();
        CreateMap<V1LogoutResponse, EmptyResponse>();
    }
}

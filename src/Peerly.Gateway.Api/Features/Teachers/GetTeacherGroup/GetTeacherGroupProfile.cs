using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherGroup;

public sealed class GetTeacherGroupProfile : Profile
{
    public GetTeacherGroupProfile()
    {
        CreateMap<GetTeacherGroupQuery, Proto.V1GetTeacherGroupRequest>();
        CreateMap<Proto.V1GetTeacherGroupResponse, GetTeacherGroupQueryResponse>();
    }
}

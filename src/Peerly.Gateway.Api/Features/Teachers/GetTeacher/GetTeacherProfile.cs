using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacher;

public sealed class GetTeacherProfile : Profile
{
    public GetTeacherProfile()
    {
        CreateMap<GetTeacherQuery, V1GetTeacherRequest>();
        CreateMap<V1GetTeacherResponse, GetTeacherQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudent;

public sealed class GetStudentProfile : Profile
{
    public GetStudentProfile()
    {
        CreateMap<GetStudentQuery, V1GetStudentRequest>();
        CreateMap<V1GetStudentResponse, GetStudentQueryResponse>();
    }
}

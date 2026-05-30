using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentRubric;

public sealed class GetStudentRubricProfile : Profile
{
    public GetStudentRubricProfile()
    {
        CreateMap<GetStudentRubricQuery, V1GetStudentRubricRequest>();
        CreateMap<V1GetStudentRubricResponse, GetStudentRubricQueryResponse>();
    }
}

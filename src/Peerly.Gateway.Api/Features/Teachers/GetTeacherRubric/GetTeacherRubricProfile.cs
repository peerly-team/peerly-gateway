using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherRubric;

public sealed class GetTeacherRubricProfile : Profile
{
    public GetTeacherRubricProfile()
    {
        CreateMap<GetTeacherRubricQuery, V1GetTeacherRubricRequest>();
        CreateMap<V1GetTeacherRubricResponse, GetTeacherRubricQueryResponse>();
    }
}

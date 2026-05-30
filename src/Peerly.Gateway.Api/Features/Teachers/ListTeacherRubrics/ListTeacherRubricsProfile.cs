using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherRubrics;

public sealed class ListTeacherRubricsProfile : Profile
{
    public ListTeacherRubricsProfile()
    {
        CreateMap<ListTeacherRubricsQuery, V1ListTeacherRubricsRequest>();
        CreateMap<V1ListTeacherRubricsResponse, ListTeacherRubricsQueryResponse>();
    }
}

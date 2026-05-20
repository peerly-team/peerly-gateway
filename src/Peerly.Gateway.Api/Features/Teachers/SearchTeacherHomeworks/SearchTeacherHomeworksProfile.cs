using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.SearchTeacherHomeworks;

public sealed class SearchTeacherHomeworksProfile : Profile
{
    public SearchTeacherHomeworksProfile()
    {
        CreateMap<SearchTeacherHomeworksQuery, Proto.V1SearchTeacherHomeworksRequest>();
        CreateMap<Proto.V1SearchTeacherHomeworksResponse, SearchTeacherHomeworksQueryResponse>();
    }
}

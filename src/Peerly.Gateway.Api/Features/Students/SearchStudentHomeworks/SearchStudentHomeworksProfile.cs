using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.SearchStudentHomeworks;

public sealed class SearchStudentHomeworksProfile : Profile
{
    public SearchStudentHomeworksProfile()
    {
        CreateMap<SearchStudentHomeworksQuery, Proto.V1SearchStudentHomeworksRequest>();
        CreateMap<Proto.V1SearchStudentHomeworksResponse, SearchStudentHomeworksQueryResponse>();
    }
}

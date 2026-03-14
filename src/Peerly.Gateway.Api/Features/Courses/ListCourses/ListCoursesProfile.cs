using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Courses.ListCourses;

public sealed class ListCoursesProfile : Profile
{
    public ListCoursesProfile()
    {
        CreateMap<ListCoursesFilter, Proto.SearchCoursesFilter>();
        CreateMap<ListCoursesQuery, Proto.V1SearchCoursesRequest>();
        CreateMap<Proto.V1SearchCoursesResponse, ListCoursesQueryResponse>();
    }
}

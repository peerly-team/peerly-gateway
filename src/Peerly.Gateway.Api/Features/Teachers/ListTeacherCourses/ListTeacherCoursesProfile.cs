using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourses;

public sealed class ListTeacherCoursesProfile : Profile
{
    public ListTeacherCoursesProfile()
    {
        CreateMap<ListTeacherCoursesFilter, Proto.SearchCoursesFilter>();
        CreateMap<ListTeacherCoursesQuery, Proto.V1SearchTeacherCoursesRequest>();
        CreateMap<Proto.V1SearchTeacherCoursesResponse, ListTeacherCoursesQueryResponse>();
    }
}

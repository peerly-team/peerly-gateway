using AutoMapper;
using Peerly.Gateway.Api.Models.Course;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Courses.ListCourses;

public sealed class ListCoursesProfile : Profile
{
    public ListCoursesProfile()
    {
        CreateMap<ListCoursesFilter, Proto.SearchCoursesFilter>();
        CreateMap<PaginationInfo, Proto.PaginationInfo>();
        CreateMap<ListCoursesQuery, Proto.V1SearchCoursesRequest>();
        CreateMap<Proto.CourseInfo, CourseInfo>();
        CreateMap<Proto.V1SearchCoursesResponse, ListCoursesQueryResponse>();
    }
}

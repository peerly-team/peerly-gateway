using AutoMapper;
using Peerly.Gateway.Api.Models.Course;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourses;

public sealed class ListTeacherCoursesProfile : Profile
{
    public ListTeacherCoursesProfile()
    {
        CreateMap<ListTeacherCoursesFilter, Proto.SearchCoursesFilter>();
        CreateMap<PaginationInfo, Proto.PaginationInfo>();
        CreateMap<ListTeacherCoursesQuery, Proto.V1SearchTeacherCoursesRequest>();
        CreateMap<Proto.CourseInfo, CourseInfo>();
        CreateMap<Proto.V1SearchTeacherCoursesResponse, ListTeacherCoursesQueryResponse>();
    }
}

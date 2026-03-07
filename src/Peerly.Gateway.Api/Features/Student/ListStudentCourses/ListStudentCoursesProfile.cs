using AutoMapper;
using Peerly.Gateway.Api.Models.Course;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Student.ListStudentCourses;

public sealed class ListStudentCoursesProfile : Profile
{
    public ListStudentCoursesProfile()
    {
        CreateMap<ListStudentCoursesFilter, Proto.SearchCoursesFilter>();
        CreateMap<PaginationInfo, Proto.PaginationInfo>();
        CreateMap<ListStudentCoursesQuery, Proto.V1SearchStudentCoursesRequest>();
        CreateMap<Proto.CourseInfo, CourseInfo>();
        CreateMap<Proto.V1SearchStudentCoursesResponse, ListStudentCoursesQueryResponse>();
    }
}

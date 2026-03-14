using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Student.ListStudentCourses;

public sealed class ListStudentCoursesProfile : Profile
{
    public ListStudentCoursesProfile()
    {
        CreateMap<ListStudentCoursesFilter, Proto.SearchCoursesFilter>();
        CreateMap<ListStudentCoursesQuery, Proto.V1SearchStudentCoursesRequest>();
        CreateMap<Proto.V1SearchStudentCoursesResponse, ListStudentCoursesQueryResponse>();
    }
}

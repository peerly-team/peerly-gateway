using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseGroups;

public sealed class ListStudentCourseGroupsProfile : Profile
{
    public ListStudentCourseGroupsProfile()
    {
        CreateMap<ListStudentCourseGroupsQuery, Proto.V1ListStudentCourseGroupsRequest>();
        CreateMap<Proto.V1ListStudentCourseGroupsResponse, ListStudentCourseGroupsQueryResponse>();
    }
}

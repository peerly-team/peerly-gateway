using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseGroups;

public sealed class ListTeacherCourseGroupsProfile : Profile
{
    public ListTeacherCourseGroupsProfile()
    {
        CreateMap<ListTeacherCourseGroupsQuery, Proto.V1ListTeacherCourseGroupsRequest>();
        CreateMap<Proto.V1ListTeacherCourseGroupsResponse, ListTeacherCourseGroupsQueryResponse>();
    }
}

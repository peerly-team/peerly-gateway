using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseHomeworks;

public sealed class ListTeacherCourseHomeworksProfile : Profile
{
    public ListTeacherCourseHomeworksProfile()
    {
        CreateMap<ListTeacherCourseHomeworksQuery, Proto.V1ListTeacherCourseHomeworksRequest>();
        CreateMap<Proto.V1ListTeacherCourseHomeworksResponse, ListTeacherCourseHomeworksQueryResponse>();
    }
}

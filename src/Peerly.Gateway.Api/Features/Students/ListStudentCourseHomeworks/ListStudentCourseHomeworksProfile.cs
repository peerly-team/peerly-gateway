using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseHomeworks;

public sealed class ListStudentCourseHomeworksProfile : Profile
{
    public ListStudentCourseHomeworksProfile()
    {
        CreateMap<ListStudentCourseHomeworksQuery, Proto.V1ListStudentCourseHomeworksRequest>();
        CreateMap<Proto.V1ListStudentCourseHomeworksResponse, ListStudentCourseHomeworksQueryResponse>();
    }
}

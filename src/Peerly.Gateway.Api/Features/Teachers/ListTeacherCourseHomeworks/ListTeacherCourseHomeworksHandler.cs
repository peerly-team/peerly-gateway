using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseHomeworks;

public sealed class ListTeacherCourseHomeworksHandler :
    FeatureHandlerAdapter<ListTeacherCourseHomeworksQuery, ListTeacherCourseHomeworksQueryResponse, V1ListTeacherCourseHomeworksRequest, V1ListTeacherCourseHomeworksResponse>
{
    public ListTeacherCourseHomeworksHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1ListTeacherCourseHomeworksAsync, mapper)
    {
    }
}

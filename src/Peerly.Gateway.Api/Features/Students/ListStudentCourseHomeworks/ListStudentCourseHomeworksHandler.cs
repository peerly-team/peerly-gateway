using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseHomeworks;

public sealed class ListStudentCourseHomeworksHandler :
    FeatureHandlerAdapter<ListStudentCourseHomeworksQuery, ListStudentCourseHomeworksQueryResponse, V1ListStudentCourseHomeworksRequest, V1ListStudentCourseHomeworksResponse>
{
    public ListStudentCourseHomeworksHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1ListStudentCourseHomeworksAsync, mapper)
    {
    }
}

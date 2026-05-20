using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.SearchTeacherHomeworks;

public sealed class SearchTeacherHomeworksHandler :
    FeatureHandlerAdapter<SearchTeacherHomeworksQuery, SearchTeacherHomeworksQueryResponse, V1SearchTeacherHomeworksRequest, V1SearchTeacherHomeworksResponse>
{
    public SearchTeacherHomeworksHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1SearchTeacherHomeworksAsync, mapper)
    {
    }
}

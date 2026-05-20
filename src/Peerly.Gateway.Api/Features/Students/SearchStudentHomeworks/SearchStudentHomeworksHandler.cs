using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.SearchStudentHomeworks;

public sealed class SearchStudentHomeworksHandler :
    FeatureHandlerAdapter<SearchStudentHomeworksQuery, SearchStudentHomeworksQueryResponse, V1SearchStudentHomeworksRequest, V1SearchStudentHomeworksResponse>
{
    public SearchStudentHomeworksHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1SearchStudentHomeworksAsync, mapper)
    {
    }
}

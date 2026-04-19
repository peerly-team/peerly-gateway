using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentHomework;

public sealed class GetStudentHomeworkHandler :
    FeatureHandlerAdapter<GetStudentHomeworkQuery, GetStudentHomeworkQueryResponse, V1GetStudentHomeworkRequest, V1GetStudentHomeworkResponse>
{
    public GetStudentHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1GetStudentHomeworkAsync, mapper)
    {
    }
}

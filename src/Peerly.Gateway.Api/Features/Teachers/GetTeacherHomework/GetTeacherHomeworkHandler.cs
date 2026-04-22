using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherHomework;

public sealed class GetTeacherHomeworkHandler :
    FeatureHandlerAdapter<GetTeacherHomeworkQuery, GetTeacherHomeworkQueryResponse, V1GetTeacherHomeworkRequest, V1GetTeacherHomeworkResponse>
{
    public GetTeacherHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1GetTeacherHomeworkAsync, mapper)
    {
    }
}

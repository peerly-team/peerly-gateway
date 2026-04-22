using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherSubmittedHomework;

public sealed class GetTeacherSubmittedHomeworkHandler :
    FeatureHandlerAdapter<GetTeacherSubmittedHomeworkQuery, GetTeacherSubmittedHomeworkQueryResponse, V1GetTeacherSubmittedHomeworkRequest, V1GetTeacherSubmittedHomeworkResponse>
{
    public GetTeacherSubmittedHomeworkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1GetTeacherSubmittedHomeworkAsync, mapper)
    {
    }
}

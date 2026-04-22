using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Submissions.GetSubmittedHomework;

public sealed class GetSubmittedHomeworkHandler :
    FeatureHandlerAdapter<GetSubmittedHomeworkQuery, GetSubmittedHomeworkQueryResponse, V1GetSubmittedHomeworkRequest, V1GetSubmittedHomeworkResponse>
{
    public GetSubmittedHomeworkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1GetSubmittedHomeworkAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.UpdateSubmittedHomework;

public sealed class UpdateSubmittedHomeworkHandler :
    FeatureHandlerAdapter<UpdateSubmittedHomeworkCommand, Result<EmptyResponse>, V1UpdateSubmittedHomeworkRequest, V1UpdateSubmittedHomeworkResponse>
{
    public UpdateSubmittedHomeworkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1UpdateSubmittedHomeworkAsync, mapper)
    {
    }
}

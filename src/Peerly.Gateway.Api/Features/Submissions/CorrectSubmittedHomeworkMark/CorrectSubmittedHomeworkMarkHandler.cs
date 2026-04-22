using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.CorrectSubmittedHomeworkMark;

public sealed class CorrectSubmittedHomeworkMarkHandler :
    FeatureHandlerAdapter<CorrectSubmittedHomeworkMarkCommand, Result<EmptyResponse>, V1CorrectSubmittedHomeworkMarkRequest, V1CorrectSubmittedHomeworkMarkResponse>
{
    public CorrectSubmittedHomeworkMarkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1CorrectSubmittedHomeworkMarkAsync, mapper)
    {
    }
}

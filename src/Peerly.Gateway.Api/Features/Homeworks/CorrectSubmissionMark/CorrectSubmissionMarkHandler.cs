using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CorrectSubmissionMark;

public sealed class CorrectSubmissionMarkHandler :
    FeatureHandlerAdapter<CorrectSubmissionMarkCommand, Result<EmptyResponse>, V1CorrectSubmissionMarkRequest, V1CorrectSubmissionMarkResponse>
{
    public CorrectSubmissionMarkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1CorrectSubmissionMarkAsync, mapper)
    {
    }
}

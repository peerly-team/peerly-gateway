using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteSubmittedHomework;

public sealed class DeleteSubmittedHomeworkHandler :
    FeatureHandlerAdapter<DeleteSubmittedHomeworkCommand, Result<EmptyResponse>, V1DeleteSubmittedHomeworkRequest, V1DeleteSubmittedHomeworkResponse>
{
    public DeleteSubmittedHomeworkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1DeleteSubmittedHomeworkAsync, mapper)
    {
    }
}

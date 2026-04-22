using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomework;

public sealed class CreateSubmittedHomeworkHandler : FeatureHandlerAdapter<
    CreateSubmittedHomeworkCommand, Result<CreateSubmittedHomeworkCommandResponse>, V1CreateSubmittedHomeworkRequest, V1CreateSubmittedHomeworkResponse>
{
    public CreateSubmittedHomeworkHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1CreateSubmittedHomeworkAsync, mapper)
    {
    }
}

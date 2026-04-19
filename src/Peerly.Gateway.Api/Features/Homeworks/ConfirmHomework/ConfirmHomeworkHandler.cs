using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.ConfirmHomework;

public sealed class ConfirmHomeworkHandler :
    FeatureHandlerAdapter<ConfirmHomeworkCommand, Result<EmptyResponse>, V1ConfirmHomeworkRequest, V1ConfirmHomeworkResponse>
{
    public ConfirmHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1ConfirmHomeworkAsync, mapper)
    {
    }
}

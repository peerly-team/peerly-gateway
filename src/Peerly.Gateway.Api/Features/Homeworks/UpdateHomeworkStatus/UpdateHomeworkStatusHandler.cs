using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateHomeworkStatus;

public sealed class UpdateHomeworkStatusHandler : FeatureHandlerAdapter<
    UpdateHomeworkStatusCommand, Result<EmptyResponse>, V1UpdateHomeworkStatusRequest, V1UpdateHomeworkStatusResponse>
{
    public UpdateHomeworkStatusHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1UpdateHomeworkStatusAsync, mapper)
    {
    }
}

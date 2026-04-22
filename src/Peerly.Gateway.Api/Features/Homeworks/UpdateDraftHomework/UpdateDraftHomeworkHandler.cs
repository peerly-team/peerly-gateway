using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.UpdateDraftHomework;

public sealed class UpdateDraftHomeworkHandler : FeatureHandlerAdapter<
    UpdateDraftHomeworkCommand, Result<EmptyResponse>, V1UpdateDraftHomeworkRequest, V1UpdateDraftHomeworkResponse>
{
    public UpdateDraftHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1UpdateDraftHomeworkAsync, mapper)
    {
    }
}

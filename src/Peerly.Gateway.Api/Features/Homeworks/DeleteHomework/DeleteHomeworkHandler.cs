using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteHomework;

public sealed class DeleteHomeworkHandler :
    FeatureHandlerAdapter<DeleteHomeworkCommand, Result<EmptyResponse>, V1DeleteHomeworkRequest, V1DeleteHomeworkResponse>
{
    public DeleteHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1DeleteHomeworkAsync, mapper)
    {
    }
}

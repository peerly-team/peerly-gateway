using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.PublishHomework;

public sealed class PublishHomeworkHandler : FeatureHandlerAdapter<
    PublishHomeworkCommand, Result<EmptyResponse>, V1PublishHomeworkRequest, V1PublishHomeworkResponse>
{
    public PublishHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1PublishHomeworkAsync, mapper)
    {
    }
}

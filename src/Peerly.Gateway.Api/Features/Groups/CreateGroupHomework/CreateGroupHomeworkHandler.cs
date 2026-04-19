using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.CreateGroupHomework;

public sealed class CreateGroupHomeworkHandler :
    FeatureHandlerAdapter<CreateGroupHomeworkCommand, Result<CreateGroupHomeworkCommandResponse>, V1CreateGroupHomeworkRequest, V1CreateGroupHomeworkResponse>
{
    public CreateGroupHomeworkHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1CreateGroupHomeworkAsync, mapper)
    {
    }
}

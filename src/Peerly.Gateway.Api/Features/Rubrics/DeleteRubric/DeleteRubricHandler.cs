using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.DeleteRubric;

public sealed class DeleteRubricHandler : FeatureHandlerAdapter<
    DeleteRubricCommand, Result<EmptyResponse>, V1DeleteRubricRequest, V1DeleteRubricResponse>
{
    public DeleteRubricHandler(RubricService.RubricServiceClient client, IMapper mapper)
        : base(client.V1DeleteRubricAsync, mapper)
    {
    }
}

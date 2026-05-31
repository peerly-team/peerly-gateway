using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.UpdateRubric;

public sealed class UpdateRubricHandler : FeatureHandlerAdapter<
    UpdateRubricCommand, Result<EmptyResponse>, V1UpdateRubricRequest, V1UpdateRubricResponse>
{
    public UpdateRubricHandler(RubricService.RubricServiceClient client, IMapper mapper)
        : base(client.V1UpdateRubricAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.CreateRubric;

public sealed class CreateRubricHandler : FeatureHandlerAdapter<
    CreateRubricCommand, Result<CreateRubricCommandResponse>, V1CreateRubricRequest, V1CreateRubricResponse>
{
    public CreateRubricHandler(RubricService.RubricServiceClient client, IMapper mapper)
        : base(client.V1CreateRubricAsync, mapper)
    {
    }
}

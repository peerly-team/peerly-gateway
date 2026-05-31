using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Rubrics.CreateRubric;
using Peerly.Gateway.Api.Features.Rubrics.DeleteRubric;
using Peerly.Gateway.Api.Features.Rubrics.UpdateRubric;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Rubrics;

[Route("api/v1/rubrics")]
[RpcExceptionFilter]
public sealed class RubricController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public RubricController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.CreateRubric)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateRubricCommandResponse>> CreateRubric(
        [FromBody] CreateRubricRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateRubricCommand
        {
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.UpdateRubric)]
    [HttpPut("{rubricId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateRubric(
        [FromRoute] long rubricId,
        [FromBody] UpdateRubricRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new UpdateRubricCommand
        {
            RubricId = rubricId,
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.DeleteRubric)]
    [HttpDelete("{rubricId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteRubric(
        [FromRoute] long rubricId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteRubricCommand
        {
            RubricId = rubricId,
            TeacherId = User.GetUserId()
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

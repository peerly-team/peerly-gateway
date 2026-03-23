using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.CreateHomeworkFile;
using Peerly.Gateway.Api.Features.Homeworks.UpdateHomeworkStatus;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Homeworks;

[Route("api/v1/homeworks")]
[RpcExceptionFilter]
public sealed partial class HomeworkController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public HomeworkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.UpdateHomeworkStatus)]
    [HttpPut("{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateHomeworkStatus(
        [FromRoute] long homeworkId,
        [FromBody] UpdateHomeworkStatusRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new UpdateHomeworkStatusCommand
        {
            HomeworkId = homeworkId,
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.CreateHomeworkFile)]
    [HttpPost("{homeworkId:long}/file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateHomeworkFileCommandResponse>> CreateHomeworkFile(
        [FromRoute] long homeworkId,
        [FromBody] CreateHomeworkFileRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new CreateHomeworkFileCommand
        {
            HomeworkId = homeworkId,
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

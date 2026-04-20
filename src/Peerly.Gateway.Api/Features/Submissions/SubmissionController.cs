using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.UpdateSubmittedHomework;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Submissions;

[Route("api/v1/submissions")]
[RpcExceptionFilter]
public sealed class SubmissionController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public SubmissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.UpdateSubmittedHomework)]
    [HttpPut("{submissionId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateSubmittedHomework(
        [FromRoute] long submissionId,
        [FromBody] UpdateSubmittedHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new UpdateSubmittedHomeworkCommand
        {
            SubmittedHomeworkId = submissionId,
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

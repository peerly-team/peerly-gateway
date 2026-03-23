using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomework;
using Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomeworkFile;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Api.Features.Homeworks;

public sealed partial class HomeworkController
{
    [HasPermission(ApiPermission.CreateSubmittedHomework)]
    [HttpPost("{homeworkId:long}/submit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateSubmittedHomeworkCommandResponse>> CreateSubmittedHomework(
        [FromRoute] long homeworkId,
        [FromBody] CreateSubmittedHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new CreateSubmittedHomeworkCommand
        {
            HomeworkId = homeworkId,
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.CreateSubmittedHomework)]
    [HttpPost("submit/{submittedHomeworkId}/file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateSubmittedHomeworkFileCommandResponse>> CreateSubmittedHomeworkFile(
        [FromRoute] long submittedHomeworkId,
        [FromBody] CreateSubmittedHomeworkFileRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new CreateSubmittedHomeworkFileCommand
        {
            SubmittedHomeworkId = submittedHomeworkId,
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

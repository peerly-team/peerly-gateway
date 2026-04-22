using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Submissions.CorrectSubmittedHomeworkMark;
using Peerly.Gateway.Api.Features.Submissions.CreateSubmittedHomeworkFile;
using Peerly.Gateway.Api.Features.Submissions.CreateSubmittedReview;
using Peerly.Gateway.Api.Features.Submissions.DeleteSubmittedHomework;
using Peerly.Gateway.Api.Features.Submissions.DeleteSubmittedHomeworkFile;
using Peerly.Gateway.Api.Features.Submissions.GetAssignedReview;
using Peerly.Gateway.Api.Features.Submissions.GetSubmittedHomework;
using Peerly.Gateway.Api.Features.Submissions.UpdateSubmittedHomework;
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

    [HasPermission(ApiPermission.GetSubmittedHomework)]
    [HttpGet("{submissionId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetSubmittedHomeworkQueryResponse>> GetSubmittedHomework(
        [FromRoute] long submissionId,
        CancellationToken cancellationToken)
    {
        var query = new GetSubmittedHomeworkQuery
        {
            SubmittedHomeworkId = submissionId,
            StudentId = User.GetUserId()
        };
        return await _mediator.Send(query, cancellationToken);
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

    [HasPermission(ApiPermission.DeleteSubmittedHomework)]
    [HttpDelete("{submissionId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteSubmittedHomework(
        [FromRoute] long submissionId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteSubmittedHomeworkCommand
        {
            SubmittedHomeworkId = submissionId,
            StudentId = User.GetUserId()
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.CreateSubmittedHomework)]
    [HttpPost("{submissionId:long}/file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateSubmittedHomeworkFileCommandResponse>> CreateSubmittedHomeworkFile(
        [FromRoute] long submissionId,
        [FromBody] CreateSubmittedHomeworkFileRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateSubmittedHomeworkFileCommand
        {
            SubmittedHomeworkId = submissionId,
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.DeleteSubmittedHomeworkFile)]
    [HttpDelete("{submissionId:long}/files/{fileId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteSubmittedHomeworkFile(
        [FromRoute] long submissionId,
        [FromRoute] long fileId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteSubmittedHomeworkFileCommand
        {
            SubmittedHomeworkId = submissionId,
            FileId = fileId,
            StudentId = User.GetUserId()
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.GetAssignedReview)]
    [HttpGet("{submissionId:long}/reviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetAssignedReviewQueryResponse>> GetAssignedReview(
        [FromRoute] long submissionId,
        CancellationToken cancellationToken)
    {
        var query = new GetAssignedReviewQuery
        {
            SubmittedHomeworkId = submissionId,
            StudentId = User.GetUserId()
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.CreateSubmittedReview)]
    [HttpPost("{submissionId:long}/reviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateSubmittedReviewCommandResponse>> CreateSubmittedReview(
        [FromRoute] long submissionId,
        [FromBody] CreateSubmittedReviewRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateSubmittedReviewCommand
        {
            SubmittedHomeworkId = submissionId,
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.CorrectSubmittedHomeworkMark)]
    [HttpPut("{submissionId:long}/mark")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> CorrectSubmittedHomeworkMark(
        [FromRoute] long submissionId,
        [FromBody] CorrectSubmittedHomeworkMarkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CorrectSubmittedHomeworkMarkCommand
        {
            SubmittedHomeworkId = submissionId,
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

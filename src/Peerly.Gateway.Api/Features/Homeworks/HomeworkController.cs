using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.ConfirmHomework;
using Peerly.Gateway.Api.Features.Homeworks.CreateHomeworkFile;
using Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomework;
using Peerly.Gateway.Api.Features.Homeworks.DeleteHomework;
using Peerly.Gateway.Api.Features.Homeworks.ListAssignedReviews;
using Peerly.Gateway.Api.Features.Homeworks.PostponeHomeworkDeadlines;
using Peerly.Gateway.Api.Features.Homeworks.PublishHomework;
using Peerly.Gateway.Api.Features.Homeworks.UpdateDraftHomework;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Homeworks;

[Route("api/v1/homeworks")]
[RpcExceptionFilter]
public sealed class HomeworkController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public HomeworkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.UpdateDraftHomework)]
    [HttpPut("{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateDraftHomework(
        [FromRoute] long homeworkId,
        [FromBody] UpdateDraftHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new UpdateDraftHomeworkCommand
        {
            TeacherId = User.GetUserId(),
            HomeworkId = homeworkId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.PostponeHomeworkDeadlines)]
    [HttpPut("{homeworkId:long}/deadlines")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> PostponeHomeworkDeadlines(
        [FromRoute] long homeworkId,
        [FromBody] PostponeHomeworkDeadlinesRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new PostponeHomeworkDeadlinesCommand
        {
            TeacherId = User.GetUserId(),
            HomeworkId = homeworkId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.PublishHomework)]
    [HttpPut("{homeworkId:long}/publish")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> PublishHomework([FromRoute] long homeworkId, CancellationToken cancellationToken)
    {
        var command = new PublishHomeworkCommand
        {
            TeacherId = User.GetUserId(),
            HomeworkId = homeworkId
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.ConfirmHomework)]
    [HttpPut("{homeworkId:long}/confirm")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> ConfirmHomework([FromRoute] long homeworkId, CancellationToken cancellationToken)
    {
        var command = new ConfirmHomeworkCommand
        {
            TeacherId = User.GetUserId(),
            HomeworkId = homeworkId
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.DeleteHomework)]
    [HttpDelete("{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteHomework(
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteHomeworkCommand
        {
            TeacherId = User.GetUserId(),
            HomeworkId = homeworkId
        };
        var response = await _mediator.Send(command, cancellationToken);

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

    [HasPermission(ApiPermission.CreateSubmittedHomework)]
    [HttpPost("{homeworkId:long}/submissions")]
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

    [HasPermission(ApiPermission.ListAssignedReviews)]
    [HttpGet("{homeworkId:long}/assigned-reviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListAssignedReviewsQueryResponse>> ListAssignedReviews(
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new ListAssignedReviewsQuery
        {
            HomeworkId = homeworkId,
            StudentId = User.GetUserId()
        };
        return await _mediator.Send(query, cancellationToken);
    }
}

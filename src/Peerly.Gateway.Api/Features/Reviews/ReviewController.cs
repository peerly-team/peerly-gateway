using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Reviews.DeleteSubmittedReview;
using Peerly.Gateway.Api.Features.Reviews.GetSubmittedReview;
using Peerly.Gateway.Api.Features.Reviews.UpdateSubmittedReview;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Reviews;

[Route("api/v1/reviews")]
[RpcExceptionFilter]
public sealed class ReviewController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.GetSubmittedReview)]
    [HttpGet("{reviewId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetSubmittedReviewQueryResponse>> GetSubmittedReview(
        [FromRoute] long reviewId,
        CancellationToken cancellationToken)
    {
        var query = new GetSubmittedReviewQuery
        {
            SubmittedReviewId = reviewId,
            StudentId = User.GetUserId()
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.UpdateSubmittedReview)]
    [HttpPut("{reviewId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateSubmittedReview(
        [FromRoute] long reviewId,
        [FromBody] UpdateSubmittedReviewRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new UpdateSubmittedReviewCommand
        {
            SubmittedReviewId = reviewId,
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.DeleteSubmittedReview)]
    [HttpDelete("{reviewId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteSubmittedReview(
        [FromRoute] long reviewId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteSubmittedReviewCommand
        {
            SubmittedReviewId = reviewId,
            StudentId = User.GetUserId()
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

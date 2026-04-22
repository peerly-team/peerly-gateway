using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.ListAssignedReviews;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Api.Features.Homeworks;

public sealed partial class HomeworkController
{
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

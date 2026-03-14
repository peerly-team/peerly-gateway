using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.AddSubmission;
using Peerly.Gateway.Api.Features.Homeworks.ListSubmissions;
using Peerly.Gateway.Api.Features.Homeworks.UpdateSubmission;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Models.Submission;

namespace Peerly.Gateway.Api.Features.Homeworks;

public sealed partial class HomeworkController
{
    /// <summary>
    /// Для преподавателя выводит список ответов студентов, а для студента только его ответ
    /// </summary>
    /// <returns></returns>
    [HasPermission(ApiPermission.ListSubmissions)]
    [HttpGet("{homeworkId:long}/submissions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListSubmissionsQueryResponse>> ListSubmissions(
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new ListSubmissionsQuery
        {
            HomeworkId = homeworkId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!)
        };

        return await Task.FromResult(new ListSubmissionsQueryResponse
        {
            Submissions =
            [
                new Submission
                {
                    UserId = 1,
                    Comment = "В первой задаче реализация через ..., а в пятой не успел сделать это.",
                    Files = []
                },
                new Submission
                {
                    UserId = 2,
                    Files = []
                }
            ]
        });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.AddSubmission)]
    [HttpPost("{homeworkId:long}/submissions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddSubmission(
        [FromRoute] long homeworkId,
        [FromBody] AddSubmissionRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new AddSubmissionCommand
        {
            HomeworkId = homeworkId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.UpdateSubmission)]
    [HttpPut("{homeworkId:long}/submissions/{submissionId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateSubmission(
        [FromRoute] long homeworkId,
        [FromRoute] long submissionId,
        [FromBody] UpdateSubmissionRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new UpdateSubmissionCommand
        {
            HomeworkId = homeworkId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

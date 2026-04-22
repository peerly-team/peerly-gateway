using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Homeworks.GetHomework;
using Peerly.Gateway.Api.Features.Homeworks.UpdateHomework;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Homeworks;

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

    [HasPermission(ApiPermission.GetHomework)]
    [HttpGet("{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetHomeworkQueryResponse>> GetHomework(
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new GetHomeworkQuery
        {
            HomeworkId = homeworkId
        };

        return await Task.FromResult(
            new GetHomeworkQueryResponse
            {
                Homework = new Homework
                {
                    Name = "Большая домашка #2",
                    Status = HomeworkStatus.InProgress,
                    Description = "123123123",
                    Deadline = DateTimeOffset.Now.AddDays(5),
                    AmountOfReviews = 3
                }
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.UpdateHomework)]
    [HttpPut("{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateHomework(
        [FromRoute] long homeworkId,
        [FromBody] UpdateHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        // todo: добавить на пустой фильтр проверку. все поля null нельзя
        var query = new UpdateHomeworkCommand
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

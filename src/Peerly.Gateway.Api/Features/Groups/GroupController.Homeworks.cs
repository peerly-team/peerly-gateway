using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Groups.AddGroupHomework;
using Peerly.Gateway.Api.Features.Groups.DeleteGroupHomework;
using Peerly.Gateway.Api.Features.Groups.ListGroupHomeworks;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Groups;

public sealed partial class GroupController
{
    // NOTE: отдает список домашних заданий, которые прикреплены к группе
    [HasPermission(ApiPermission.ListGroupHomeworks)]
    [HttpGet("{groupId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListGroupHomeworksQueryResponse>> ListHomeworks(
        [FromRoute] long groupId,
        [FromQuery] ListGroupHomeworksFilter filter,
        CancellationToken cancellationToken)
    {
        // todo: если role = Student, исключаем домашки, которые ещё не опубликованы
        var query = new ListGroupHomeworksQuery
        {
            GroupId = groupId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            Role = Enum.Parse<Role>(User.FindFirstValue(ClaimTypes.Role)!),
            Filter = filter
        };

        return await Task.FromResult(
            new ListGroupHomeworksQueryResponse
            {
                Homeworks =
                [
                    new Homework
                    {
                        Name = "Маленька домашка #1",
                        Status = HomeworkStatus.Closed,
                        Description = "123123123",
                        Deadline = DateTimeOffset.Now.AddDays(-5),
                        AmountOfReviews = 3
                    },
                    new Homework
                    {
                        Name = "Маленькая домашка #2",
                        Status = HomeworkStatus.InProgress,
                        Description = "123123123",
                        Deadline = DateTimeOffset.Now.AddDays(5),
                        AmountOfReviews = 3
                    }
                ]
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: создает новое домашнее задание для группы в статусе "Черновик"
    [HasPermission(ApiPermission.AddGroupHomework)]
    [HttpPost("{groupId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddHomework(
        [FromRoute] long groupId,
        [FromBody] AddGroupHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new AddGroupHomeworkCommand
        {
            GroupId = groupId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }


    [HasPermission(ApiPermission.DeleteGroupHomework)]
    [HttpDelete("{groupId:long}/homeworks/{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteCourseHomework(
        [FromRoute] long groupId,
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new DeleteGroupHomeworkCommand
        {
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            GroupId = groupId,
            HomeworkId = homeworkId,
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

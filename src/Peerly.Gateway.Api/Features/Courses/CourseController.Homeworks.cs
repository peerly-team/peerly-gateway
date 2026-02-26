using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.AddCourseHomework;
using Peerly.Gateway.Api.Features.Courses.DeleteCourseHomework;
using Peerly.Gateway.Api.Features.Courses.ListCourseHomeworks;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Courses;

public sealed partial class CourseController
{
    // NOTE: отдает список домашних заданий, которые прикреплены к курсу
    [HasPermission(ApiPermission.ListCourseHomeworks)]
    [HttpGet("{courseId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListCourseHomeworksQueryResponse>> ListCourseHomeworks(
        [FromRoute] long courseId,
        [FromQuery] ListCourseHomeworksFilter filter,
        CancellationToken cancellationToken)
    {
        // todo: если role = Student, исключаем домашки, которые ещё не опубликованы
        var query = new ListCourseHomeworksQuery
        {
            CourseId = courseId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            Role = Enum.Parse<Role>(User.FindFirstValue(ClaimTypes.Role)!),
            Filter = filter
        };

        return await Task.FromResult(
            new ListCourseHomeworksQueryResponse
            {
                Homeworks =
                [
                    new Homework
                    {
                        Name = "Большая домашка #1",
                        Status = HomeworkStatus.Closed,
                        Description = "123123123",
                        Deadline = DateTimeOffset.Now.AddDays(-5),
                        AmountOfReviews = 3
                    },
                    new Homework
                    {
                        Name = "Большая домашка #2",
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

    // NOTE: создает новое домашнее задание для курса в статусе "Черновик"
    [HasPermission(ApiPermission.AddCourseHomework)]
    [HttpPost("{courseId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddCourseHomework(
        [FromRoute] long courseId,
        [FromBody] AddCourseHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new AddCourseHomeworkCommand
        {
            CourseId = courseId,
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.DeleteCourseHomework)]
    [HttpDelete("{courseId:long}/homeworks/{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteCourseHomework(
        [FromRoute] long courseId,
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new DeleteCourseHomeworkCommand
        {
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            CourseId = courseId,
            HomeworkId = homeworkId,
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

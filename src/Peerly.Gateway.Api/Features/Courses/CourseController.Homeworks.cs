using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.AddCourseHomework;
using Peerly.Gateway.Api.Features.Courses.DeleteCourseHomework;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Api.Features.Courses;

public sealed partial class CourseController
{

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
            TeacherId = User.GetUserId(),
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

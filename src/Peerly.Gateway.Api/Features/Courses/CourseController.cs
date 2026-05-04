using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.CreateCourse;
using Peerly.Gateway.Api.Features.Courses.CreateCourseFile;
using Peerly.Gateway.Api.Features.Courses.CreateCourseHomework;
using Peerly.Gateway.Api.Features.Courses.DeleteCourse;
using Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;
using Peerly.Gateway.Api.Features.Courses.PublishCourse;
using Peerly.Gateway.Api.Features.Courses.UpdateCourse;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Courses;

[Route("api/v1/courses")]
[RpcExceptionFilter]
public sealed class CourseController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.CreateCourse)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> CreateCourse(
        [FromBody] CreateCourseRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateCourseCommand
        {
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.UpdateCourse)]
    [HttpPut("{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateCourse(
        [FromRoute] long courseId,
        [FromBody] UpdateCourseRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new UpdateCourseCommand
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.PublishCourse)]
    [HttpPut("{courseId:long}/publish")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> PublishCourse(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new PublishCourseCommand
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId
        };
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }


    [HasPermission(ApiPermission.DeleteCourse)]
    [HttpDelete("{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteCourse(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var command = new DeleteCourseCommand
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.CreateCourseFile)]
    [HttpPost("{courseId:long}/files")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> CreateCourseFile(
        [FromRoute] long courseId,
        [FromBody] CreateCourseFileRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateCourseFileCommand
        {
            CourseId = courseId,
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.ListCourseParticipants)]
    [HttpGet("{courseId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListCourseParticipantsQueryResponse>> ListCourseParticipants(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListCourseParticipantsQuery
        {
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.CreateCourseHomework)]
    [HttpPost("{courseId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<CreateCourseHomeworkCommandResponse>> CreateCourseHomework(
        [FromRoute] long courseId,
        [FromBody] CreateCourseHomeworkRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateCourseHomeworkCommand
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

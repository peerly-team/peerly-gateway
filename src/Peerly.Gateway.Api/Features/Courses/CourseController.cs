using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.CreateCourse;
using Peerly.Gateway.Api.Features.Courses.DeleteCourse;
using Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;
using Peerly.Gateway.Api.Features.Courses.ListCourses;
using Peerly.Gateway.Api.Features.Courses.UpdateCourse;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Course;

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

    [HasPermission(ApiPermission.ListCourses)]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListCoursesQueryResponse>> ListCourses(
        [FromQuery] ListCoursesFilter filter,
        [FromQuery] PaginationInfo paginationInfo,
        CancellationToken cancellationToken)
    {
        var query = new ListCoursesQuery
        {
            Filter = filter,
            PaginationInfo = paginationInfo
        };
        return await _mediator.Send(query, cancellationToken);
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
}

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;
using Peerly.Gateway.Api.Features.Teachers.GetTeacherGroup;
using Peerly.Gateway.Api.Features.Teachers.GetTeacherHomework;
using Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseGroups;
using Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseHomeworks;
using Peerly.Gateway.Api.Features.Teachers.ListTeacherCourses;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Teachers;

[Route("api/v1/teacher")]
[RpcExceptionFilter]
public sealed class TeacherController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.ListTeacherCourses)]
    [HttpGet("courses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListTeacherCoursesQueryResponse>> ListStudentCourses(
        [FromQuery] ListTeacherCoursesFilter filter,
        [FromQuery] PaginationInfo paginationInfo,
        CancellationToken cancellationToken)
    {
        var query = new ListTeacherCoursesQuery
        {
            TeacherId = User.GetUserId(),
            Filter = filter,
            PaginationInfo = paginationInfo
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetTeacherCourse)]
    [HttpGet("courses/{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetTeacherCourseQueryResponse>> GetCourse(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new GetTeacherCourseQuery
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetTeacherGroup)]
    [HttpGet("groups/{groupId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetTeacherGroupQueryResponse>> GetGroup(
        [FromRoute] long groupId,
        CancellationToken cancellationToken)
    {
        var query = new GetTeacherGroupQuery
        {
            TeacherId = User.GetUserId(),
            GroupId = groupId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.ListTeacherCourseGroups)]
    [HttpGet("courses/{courseId:long}/groups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListTeacherCourseGroupsQueryResponse>> ListCourseGroups(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListTeacherCourseGroupsQuery
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetTeacherHomework)]
    [HttpGet("homeworks/{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetTeacherHomeworkQueryResponse>> GetHomework(
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new GetTeacherHomeworkQuery
        {
            TeacherId = User.GetUserId(),
            HomeworkId = homeworkId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.ListTeacherCourseHomeworks)]
    [HttpGet("courses/{courseId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListTeacherCourseHomeworksQueryResponse>> ListCourseHomeworks(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListTeacherCourseHomeworksQuery
        {
            TeacherId = User.GetUserId(),
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }
}

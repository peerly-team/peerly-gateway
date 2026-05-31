using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Students.GetStudent;
using Peerly.Gateway.Api.Features.Students.GetStudentCourse;
using Peerly.Gateway.Api.Features.Students.GetStudentGroup;
using Peerly.Gateway.Api.Features.Students.GetStudentHomework;
using Peerly.Gateway.Api.Features.Students.ListStudentCourseGroups;
using Peerly.Gateway.Api.Features.Students.ListStudentCourseHomeworks;
using Peerly.Gateway.Api.Features.Students.ListStudentCourses;
using Peerly.Gateway.Api.Features.Students.GetStudentRubric;
using Peerly.Gateway.Api.Features.Students.SearchStudentHomeworks;
using Peerly.Gateway.Api.Features.Students.UpdateStudent;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Course;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Students;

[Route("api/v1/student")]
[RpcExceptionFilter]
public sealed class StudentController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.GetStudent)]
    [HttpGet("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetStudentQueryResponse>> GetStudent(CancellationToken cancellationToken)
    {
        var query = new GetStudentQuery
        {
            StudentId = User.GetUserId()
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.UpdateStudent)]
    [HttpPut("me")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateStudent(
        [FromBody] UpdateStudentRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new UpdateStudentCommand
        {
            StudentId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);
        return MatchResult(response);
    }

    [HasPermission(ApiPermission.ListStudentCourses)]
    [HttpGet("courses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListStudentCoursesQueryResponse>> ListStudentCourses(
        [FromQuery] ListStudentCoursesFilter filter,
        [FromQuery] PaginationInfo paginationInfo,
        CancellationToken cancellationToken)
    {
        var query = new ListStudentCoursesQuery
        {
            StudentId = User.GetUserId(),
            Filter = filter,
            PaginationInfo = paginationInfo
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetStudentCourse)]
    [HttpGet("courses/{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetStudentCourseQueryResponse>> GetCourse(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new GetStudentCourseQuery
        {
            StudentId = User.GetUserId(),
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.ListStudentCourseHomeworks)]
    [HttpGet("courses/{courseId:long}/homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListStudentCourseHomeworksQueryResponse>> ListCourseHomeworks(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListStudentCourseHomeworksQuery
        {
            StudentId = User.GetUserId(),
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.ListStudentCourseGroups)]
    [HttpGet("courses/{courseId:long}/groups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListStudentCourseGroupsQueryResponse>> ListCourseGroups(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListStudentCourseGroupsQuery
        {
            StudentId = User.GetUserId(),
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetStudentGroup)]
    [HttpGet("groups/{groupId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetStudentGroupQueryResponse>> GetGroup(
        [FromRoute] long groupId,
        CancellationToken cancellationToken)
    {
        var query = new GetStudentGroupQuery
        {
            StudentId = User.GetUserId(),
            GroupId = groupId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.SearchStudentHomeworks)]
    [HttpGet("homeworks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<SearchStudentHomeworksQueryResponse>> SearchHomeworks(
        [FromQuery] SearchHomeworksFilter filter,
        [FromQuery] PaginationInfo paginationInfo,
        CancellationToken cancellationToken)
    {
        var query = new SearchStudentHomeworksQuery
        {
            StudentId = User.GetUserId(),
            Filter = filter,
            PaginationInfo = paginationInfo
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetStudentHomework)]
    [HttpGet("homeworks/{homeworkId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetStudentHomeworkQueryResponse>> GetHomework(
        [FromRoute] long homeworkId,
        CancellationToken cancellationToken)
    {
        var query = new GetStudentHomeworkQuery
        {
            StudentId = User.GetUserId(),
            HomeworkId = homeworkId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetStudentRubric)]
    [HttpGet("rubrics/{rubricId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetStudentRubricQueryResponse>> GetRubric(
        [FromRoute] long rubricId,
        CancellationToken cancellationToken)
    {
        var query = new GetStudentRubricQuery
        {
            RubricId = rubricId,
            StudentId = User.GetUserId()
        };
        return await _mediator.Send(query, cancellationToken);
    }
}

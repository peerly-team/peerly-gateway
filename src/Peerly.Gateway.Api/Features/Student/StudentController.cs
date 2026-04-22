using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Student.GetStudentCourse;
using Peerly.Gateway.Api.Features.Student.ListStudentCourseHomeworks;
using Peerly.Gateway.Api.Features.Student.ListStudentCourses;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Student;

[Route("api/v1/student")]
[RpcExceptionFilter]
public sealed class StudentController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
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
    public async Task<ActionResult<ListStudentCourseHomeworksQueryResponse>> ListStudentCourseHomeworks(
        [FromRoute] long courseId,
        [FromQuery] ListStudentCourseHomeworksFilter filter,
        CancellationToken cancellationToken)
    {
        var query = new ListStudentCourseHomeworksQuery
        {
            StudentId = User.GetUserId(),
            CourseId = courseId,
            Filter = filter
        };

        return await Task.FromResult(new ListStudentCourseHomeworksQueryResponse());

        // todo: прикрутить к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

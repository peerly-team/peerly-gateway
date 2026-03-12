using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Student.GetStudentCourse;
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
    [HttpGet("{studentId:long}/courses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListStudentCoursesQueryResponse>> ListStudentCourses(
        [FromRoute] long studentId,
        [FromQuery] ListStudentCoursesFilter filter,
        [FromQuery] PaginationInfo paginationInfo,
        CancellationToken cancellationToken)
    {
        if (studentId != User.GetUserId())
        {
            return Forbid();
        }

        var query = new ListStudentCoursesQuery
        {
            StudentId = studentId,
            Filter = filter,
            PaginationInfo = paginationInfo
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetStudentCourse)]
    [HttpGet("{studentId:long}/courses/{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetStudentCourseQueryResponse>> GetCourse(
        [FromRoute] long studentId,
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        if (studentId != User.GetUserId())
        {
            return Forbid();
        }

        var query = new GetStudentCourseQuery
        {
            StudentId = studentId,
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }
}

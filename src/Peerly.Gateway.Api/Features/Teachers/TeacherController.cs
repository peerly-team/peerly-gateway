using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;
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
    [HttpGet("{teacherId:long}/courses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListTeacherCoursesQueryResponse>> ListStudentCourses(
        [FromRoute] long teacherId,
        [FromQuery] ListTeacherCoursesFilter filter,
        [FromQuery] PaginationInfo paginationInfo,
        CancellationToken cancellationToken)
    {
        if (teacherId != User.GetUserId())
        {
            return Forbid();
        }

        var query = new ListTeacherCoursesQuery
        {
            TeacherId = teacherId,
            Filter = filter,
            PaginationInfo = paginationInfo
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.GetTeacherCourse)]
    [HttpGet("{teacherId:long}/courses/{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetTeacherCourseQueryResponse>> GetCourse(
        [FromRoute] long teacherId,
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        if (teacherId != User.GetUserId())
        {
            return Forbid();
        }

        var query = new GetTeacherCourseQuery
        {
            TeacherId = teacherId,
            CourseId = courseId
        };
        return await _mediator.Send(query, cancellationToken);
    }
}

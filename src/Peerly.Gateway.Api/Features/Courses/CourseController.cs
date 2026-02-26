using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.AddCourse;
using Peerly.Gateway.Api.Features.Courses.DeleteCourse;
using Peerly.Gateway.Api.Features.Courses.GetCourse;
using Peerly.Gateway.Api.Features.Courses.ListCourses;
using Peerly.Gateway.Api.Features.Courses.UpdateCourse;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses;

[Route("api/v1/courses")]
[RpcExceptionFilter]
public sealed partial class CourseController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // NOTE: отдает список курсов по фильтру для пользователя
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
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            Role = Enum.Parse<Role>(User.FindFirstValue(ClaimTypes.Role)!),
            Filter = filter,
            PaginationInfo = paginationInfo
        };

        return await Task.FromResult(
            new ListCoursesQueryResponse
            {
                Courses =
                [
                    new Course
                    {
                        Id = 1,
                        Name = "test",
                        Status = CourseStatus.Draft,
                        StudentCount = 1,
                        HomeworkCount = 0
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "test-2",
                        Status = CourseStatus.InProgress,
                        StudentCount = 12,
                        HomeworkCount = 123
                    }
                ]
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: создает новый курс
    [HasPermission(ApiPermission.AddCourse)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddCourse(
        [FromBody] AddCourseRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new AddCourseCommand
        {
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: отдает информацию о курсе
    [HasPermission(ApiPermission.GetCourse)]
    [HttpGet("{courseId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetCourseQueryResponse>> GetCourse(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new GetCourseQuery
        {
            CourseId = courseId
        };

        return await Task.FromResult(
            new GetCourseQueryResponse
            {
                Course = new Course
                {
                    Id = 1,
                    Name = "test",
                    Status = CourseStatus.Draft,
                    StudentCount = 1,
                    HomeworkCount = 0
                }
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: обновляет информацию о курсе
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
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            CourseId = courseId,
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: удаляет курс, только если курс в статусе черновик
    [HasPermission(ApiPermission.DeleteCourse)]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteCourse(
        [FromBody] DeleteCourseRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new DeleteCourseCommand
        {
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

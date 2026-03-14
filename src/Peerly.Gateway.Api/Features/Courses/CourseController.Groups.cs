using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.AddCourseGroup;
using Peerly.Gateway.Api.Features.Courses.ListCourseGroups;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses;

public sealed partial class CourseController
{
    // NOTE: отдает список групп курса
    [HasPermission(ApiPermission.ListCourseGroups)]
    [HttpGet("{courseId:long}/groups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListCourseGroupsQueryResponse>> ListCourseGroups(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListCourseGroupsQuery
        {
            CourseId = courseId
        };

        return await Task.FromResult(
            new ListCourseGroupsQueryResponse
            {
                Groups =
                [
                    new Group
                    {
                        Id = 1,
                        CourseId = 1,
                        Name = "test group 1",
                        StudentCount = 0,
                        HomeworkCount = 0
                    },
                    new Group
                    {
                        Id = 2,
                        CourseId = 1,
                        Name = "test group 2",
                        StudentCount = 0,
                        HomeworkCount = 0
                    }
                ]
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: добавляет новую группу для курса
    [HasPermission(ApiPermission.AddCourseGroup)]
    [HttpPost("{courseId:long}/groups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddCourseGroup(
        [FromRoute] long courseId,
        [FromBody] AddCourseGroupRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new AddCourseGroupCommand
        {
            CourseId = courseId,
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

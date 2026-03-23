using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.AddCourseHomework;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Api.Features.Courses;

public sealed partial class CourseController
{
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
        var response = await _mediator.Send(query, cancellationToken);

        return response.Match(Ok, BadRequest, OtherError);
    }
}

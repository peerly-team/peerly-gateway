using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Groups.DeleteGroup;
using Peerly.Gateway.Api.Features.Groups.GetGroup;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Groups;

[Route("api/v1/groups")]
[RpcExceptionFilter]
public sealed partial class GroupController : ApplicationControllerBase
{
    // NOTE: удаляет участника из курса
    [HasPermission(ApiPermission.DeleteGroup)]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteGroup(
        [FromBody] DeleteGroupRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new DeleteGroupCommand
        {
            UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: отдает информацию о группе
    [HasPermission(ApiPermission.GetGroup)]
    [HttpGet("{groupId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GetGroupQueryResponse>> GetGroup(
        [FromRoute] long groupId,
        CancellationToken cancellationToken)
    {
        var query = new GetGroupQuery
        {
            GroupId = groupId
        };

        return await Task.FromResult(
            new GetGroupQueryResponse
            {
                Group = new Group
                {
                    Id = 1,
                    CourseId = 1,
                    Name = "test",
                    StudentCount = 1,
                    HomeworkCount = 0
                }
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

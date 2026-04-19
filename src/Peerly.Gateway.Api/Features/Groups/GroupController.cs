using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Groups.AddGroupStudent;
using Peerly.Gateway.Api.Features.Groups.AddGroupTeacher;
using Peerly.Gateway.Api.Features.Groups.CreateGroup;
using Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;
using Peerly.Gateway.Api.Features.Groups.UpdateGroup;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Groups;

[Route("api/v1/groups")]
[RpcExceptionFilter]
public sealed class GroupController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.CreateGroup)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> CreateGroup(
        [FromBody] CreateGroupRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new CreateGroupCommand
        {
            TeacherId = User.GetUserId(),
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);
        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.UpdateGroup)]
    [HttpPut("{groupId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> UpdateGroup(
        [FromRoute] long groupId,
        [FromBody] UpdateGroupRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new UpdateGroupCommand
        {
            TeacherId = User.GetUserId(),
            GroupId = groupId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);
        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.ListGroupParticipants)]
    [HttpGet("{groupId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListGroupParticipantsQueryResponse>> ListGroupParticipants(
        [FromRoute] long groupId,
        CancellationToken cancellationToken)
    {
        var query = new ListGroupParticipantsQuery
        {
            GroupId = groupId
        };
        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.AddGroupStudent)]
    [HttpPut("{groupId:long}/students")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddGroupStudent(
        [FromRoute] long groupId,
        [FromBody] AddGroupStudentRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new AddGroupStudentCommand
        {
            TeacherId = User.GetUserId(),
            GroupId = groupId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);
        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.AddGroupTeacher)]
    [HttpPut("{groupId:long}/teachers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddGroupTeacher(
        [FromRoute] long groupId,
        [FromBody] AddGroupTeacherRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var command = new AddGroupTeacherCommand
        {
            ActorTeacherId = User.GetUserId(),
            GroupId = groupId,
            RequestBody = requestBody
        };
        var response = await _mediator.Send(command, cancellationToken);
        return response.Match(Ok, BadRequest, OtherError);
    }
}

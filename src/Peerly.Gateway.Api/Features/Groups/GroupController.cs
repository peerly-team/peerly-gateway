using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;
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
}

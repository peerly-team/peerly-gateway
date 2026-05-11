using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Users.SearchUsers;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Users;

[Route("api/v1/users")]
[RpcExceptionFilter]
public sealed class UserController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.SearchUsers)]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<SearchUsersQueryResponse>> SearchUsers(
        [FromQuery] SearchUsersFilter filter,
        [FromQuery] int limit,
        CancellationToken cancellationToken)
    {
        var query = new SearchUsersQuery
        {
            Filter = filter,
            Limit = limit
        };
        return await _mediator.Send(query, cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Users.Register;
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

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<RegisterResponseBody>> Register(
        [FromBody] RegisterRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new RegisterCommand
        {
            RequestBody = requestBody
        };
        var response = await _mediator.Send(query, cancellationToken);

        return MatchResult(response, success => Ok(new RegisterResponseBody { UserId = success.UserId }));
    }
}

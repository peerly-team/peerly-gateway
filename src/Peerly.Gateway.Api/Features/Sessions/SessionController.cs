using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Sessions.Login;
using Peerly.Gateway.Api.Features.Sessions.Logout;
using Peerly.Gateway.Api.Features.Sessions.RefreshAccessToken;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Sessions;

[Route("api/v1/session")]
[RpcExceptionFilter]
public sealed class SessionController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public SessionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<LoginResponseBody>> Login(
        [FromBody] LoginRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new LoginCommand
        {
            RequestBody = requestBody
        };

        var response = await _mediator.Send(query, cancellationToken);

        // todo: вставить токен в куки

        return response.Match(Ok, BadRequest, OtherError);
    }

    [HasPermission(ApiPermission.Logout)]
    [HttpDelete("{userId:long}/token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<EmptyResponse>> Logout(
        [FromRoute] long userId,
        [FromBody] LogoutRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new LogoutQuery
        {
            UserId = userId,
            RequestBody = requestBody
        };

        return await _mediator.Send(query, cancellationToken);
    }

    [HasPermission(ApiPermission.Refresh)]
    [HttpPost("{userId:long}/token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<EmptyResponse>> Refresh(
        [FromRoute] long userId,
        [FromBody] RefreshRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new RefreshCommand
        {
            UserId = userId,
            RequestBody = requestBody
        };

        var response = await _mediator.Send(query, cancellationToken);

        // todo: вставить токен в куки

        return response.Match(Ok, BadRequest, OtherError);
    }
}

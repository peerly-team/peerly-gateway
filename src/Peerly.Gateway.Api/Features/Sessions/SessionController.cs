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

namespace Peerly.Gateway.Api.Features.Sessions;

[Route("api/v1/sessions")]
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

        return MatchResult(response, success => Ok(new LoginResponseBody { UserId = success.UserId }));
    }

    [HasPermission(ApiPermission.Logout)]
    [HttpDelete("token")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> Logout(CancellationToken cancellationToken)
    {
        if (!TryGetRefreshToken(out var refreshToken, out var errorResult))
            return errorResult!;

        var query = new LogoutCommand
        {
            UserId = User.GetUserId(),
            RefreshToken = refreshToken!
        };
        var response = await _mediator.Send(query, cancellationToken);

        return MatchResult(response,
            _ =>
            {
                ClearAuthCookies();
                return NoContent();
            });
    }

    [AllowAnonymous]
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> Refresh(CancellationToken cancellationToken)
    {
        if (!TryGetRefreshToken(out var refreshToken, out var errorResult))
            return errorResult!;

        var query = new RefreshCommand
        {
            UserId = User.GetUserId(),
            RefreshToken = refreshToken!
        };
        var response = await _mediator.Send(query, cancellationToken);

        return MatchResult(response, _ => NoContent());
    }
}

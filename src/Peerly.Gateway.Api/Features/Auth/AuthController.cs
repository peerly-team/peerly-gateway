using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Auth.ConfirmEmail;
using Peerly.Gateway.Api.Features.Auth.Login;
using Peerly.Gateway.Api.Features.Auth.Logout;
using Peerly.Gateway.Api.Features.Auth.Refresh;
using Peerly.Gateway.Api.Features.Auth.Register;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Auth;

[Route("api/v1/auth")]
[RpcExceptionFilter]
public sealed class AuthController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
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

    [AllowAnonymous]
    [HttpPost("register")]
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

    [AllowAnonymous]
    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> Refresh(
        [FromServices] IExpiredAccessTokenReader expiredAccessTokenReader,
        CancellationToken cancellationToken)
    {
        if (!TryGetRefreshToken(out var refreshToken, out var errorResult))
        {
            return errorResult!;
        }

        var userId = await expiredAccessTokenReader.TryGetUserIdAsync(Request, cancellationToken);
        if (userId is null)
        {
            return Unauthorized();
        }

        var query = new RefreshCommand
        {
            UserId = userId.Value,
            RefreshToken = refreshToken!
        };
        var response = await _mediator.Send(query, cancellationToken);

        return MatchResult(response, _ => NoContent());
    }

    [HasPermission(ApiPermission.Logout)]
    [HttpPost("logout")]
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
[HttpGet("confirm-email")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesDefaultResponseType(typeof(ProblemDetails))]
public async Task<ActionResult> ConfirmEmail(
    [FromQuery] ConfirmEmailFilter filter,
    CancellationToken cancellationToken)
{
    var query = new ConfirmEmailCommand
    {
        Filter = filter
    };
    var response = await _mediator.Send(query, cancellationToken);

    return MatchResult(response, Ok);
}
}

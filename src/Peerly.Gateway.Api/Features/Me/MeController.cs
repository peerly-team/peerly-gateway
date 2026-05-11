using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Me.GetRole;
using Peerly.Gateway.Api.Infrastructure;

namespace Peerly.Gateway.Api.Features.Me;

[Route("api/v1/me")]
public sealed class MeController : ApplicationControllerBase
{
    [HasPermission(ApiPermission.GetMyRole)]
    [HttpGet("role")]
    [ProducesResponseType(typeof(GetMyRoleResponse), StatusCodes.Status200OK)]
    public ActionResult<GetMyRoleResponse> GetRole()
    {
        var role = User.GetRole();
        return Ok(new GetMyRoleResponse { Role = role });
    }
}

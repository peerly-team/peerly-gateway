using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Storage;

[Route("api/v1/storage")]
[RpcExceptionFilter]
public sealed class StorageController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public StorageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(ApiPermission.GenerateUploadUrl)]
    [HttpGet("uploadUrl")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<GenerateUploadUrlQueryResponse>> GenerateUploadUrl(CancellationToken cancellationToken)
    {
        var query = new GenerateUploadUrlQuery();
        return await _mediator.Send(query, cancellationToken);
    }
}

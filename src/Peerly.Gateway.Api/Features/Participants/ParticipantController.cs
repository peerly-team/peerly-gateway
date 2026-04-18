using MediatR;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Participants;

[Route("api/v1/participants")]
[RpcExceptionFilter]
public sealed class ParticipantController : ApplicationControllerBase
{
    private readonly IMediator _mediator;

    public ParticipantController(IMediator mediator)
    {
        _mediator = mediator;
    }
}

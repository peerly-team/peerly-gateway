using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Infrastructure.Filters;

namespace Peerly.Gateway.Api.Features.Participants;

[Route("api/v1/participants")]
[RpcExceptionFilter]
public sealed class ParticipantsController : ApplicationControllerBase
{
    // todo:
    // 1. нужна ручка /api/v1/participants?role="student"&name="Павел"&email="pasha.glebov.12@mail.ru" - для выбора списка студентов
}

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Groups.AddGroupParticipant;
using Peerly.Gateway.Api.Features.Groups.DeleteGroupParticipant;
using Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Users;

namespace Peerly.Gateway.Api.Features.Groups;

public sealed partial class GroupController
{
    // NOTE: отдает список участников курса
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

        return await Task.FromResult(
            new ListGroupParticipantsQueryResponse
            {
                Participants =
                [
                    new User
                    {
                        Id = 1,
                        Name = "Глебов Павел Алексеевич",
                        Email = "paglebov_1@edu.hse.ru",
                        Role = Role.Teacher
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Карапетян Артем Гарегинович",
                        Email = "karapetos228@edu.hse.ru",
                        Role = Role.Student
                    }
                ]
            });

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: добавляет нового участника в курс
    // по ручке /api/v1/participants?role="student" предлагает список студентов, через поиск которого можно выбрать нужного и добавить
    [HasPermission(ApiPermission.AddGroupParticipant)]
    [HttpPost("{groupId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddGroupParticipant(
        [FromRoute] long groupId,
        [FromBody] AddGroupParticipantRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new AddGroupParticipantCommand
        {
            GroupId = groupId,
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: удаляет пользователя из участников курса
    [HasPermission(ApiPermission.DeleteGroupParticipant)]
    [HttpDelete("{groupId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteGroupParticipant(
        [FromRoute] long groupId,
        [FromBody] DeleteGroupParticipantRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new DeleteGroupParticipantCommand
        {
            GroupId = groupId,
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

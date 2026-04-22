using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Features.Courses.AddCourseParticipant;
using Peerly.Gateway.Api.Features.Courses.DeleteCourseParticipant;
using Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;
using Peerly.Gateway.Api.Infrastructure;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Users;

namespace Peerly.Gateway.Api.Features.Courses;

public sealed partial class CourseController
{
    // NOTE: отдает список участников курса
    [HasPermission(ApiPermission.ListCourseParticipants)]
    [HttpGet("{courseId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<ListCourseParticipantsQueryResponse>> ListCourseParticipants(
        [FromRoute] long courseId,
        CancellationToken cancellationToken)
    {
        var query = new ListCourseParticipantsQuery
        {
            CourseId = courseId
        };

        return await Task.FromResult(
            new ListCourseParticipantsQueryResponse
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
    [HasPermission(ApiPermission.AddCourseParticipant)]
    [HttpPost("{courseId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> AddCourseParticipant(
        [FromRoute] long courseId,
        [FromBody] AddCourseParticipantRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new AddCourseParticipantCommand
        {
            CourseId = courseId,
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }

    // NOTE: удаляет пользователя из участников курса
    [HasPermission(ApiPermission.DeleteCourseParticipant)]
    [HttpDelete("{courseId:long}/participants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult> DeleteCourseParticipant(
        [FromRoute] long courseId,
        [FromBody] DeleteCourseParticipantRequestBody requestBody,
        CancellationToken cancellationToken)
    {
        var query = new DeleteCourseParticipantCommand
        {
            CourseId = courseId,
            RequestBody = requestBody
        };

        return await Task.FromResult(NoContent());

        // todo: прикрутить ручку к peerly-core
        //return await _mediator.Send(query, cancellationToken);
    }
}

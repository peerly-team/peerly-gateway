using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Rubrics.DeleteRubric;

public sealed record DeleteRubricCommand : IRequest<Result<EmptyResponse>>
{
    public required long RubricId { get; init; }
    public required long TeacherId { get; init; }
}

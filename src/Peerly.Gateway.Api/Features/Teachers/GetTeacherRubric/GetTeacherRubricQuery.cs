using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherRubric;

public sealed record GetTeacherRubricQuery : IRequest<GetTeacherRubricQueryResponse>
{
    public required long RubricId { get; init; }
    public required long TeacherId { get; init; }
}

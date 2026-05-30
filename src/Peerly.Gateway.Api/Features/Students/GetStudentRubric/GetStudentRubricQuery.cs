using MediatR;

namespace Peerly.Gateway.Api.Features.Students.GetStudentRubric;

public sealed record GetStudentRubricQuery : IRequest<GetStudentRubricQueryResponse>
{
    public required long RubricId { get; init; }
    public required long StudentId { get; init; }
}

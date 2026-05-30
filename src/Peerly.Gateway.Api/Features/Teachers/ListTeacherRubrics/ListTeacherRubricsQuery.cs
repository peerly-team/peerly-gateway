using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherRubrics;

public sealed record ListTeacherRubricsQuery : IRequest<ListTeacherRubricsQueryResponse>
{
    public required long TeacherId { get; init; }
}

using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherGroup;

public sealed record GetTeacherGroupQuery : IRequest<GetTeacherGroupQueryResponse>
{
    public required long TeacherId { get; init; }
    public required long GroupId { get; init; }
}

using MediatR;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacher;

public sealed record GetTeacherQuery : IRequest<GetTeacherQueryResponse>
{
    public required long TeacherId { get; init; }
}

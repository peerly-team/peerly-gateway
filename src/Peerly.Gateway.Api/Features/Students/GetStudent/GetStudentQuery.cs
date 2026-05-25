using MediatR;

namespace Peerly.Gateway.Api.Features.Students.GetStudent;

public sealed record GetStudentQuery : IRequest<GetStudentQueryResponse>
{
    public required long StudentId { get; init; }
}

using MediatR;

namespace Peerly.Gateway.Api.Features.Students.GetStudentGroup;

public sealed record GetStudentGroupQuery : IRequest<GetStudentGroupQueryResponse>
{
    public required long StudentId { get; init; }
    public required long GroupId { get; init; }
}

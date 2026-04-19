using Peerly.Gateway.Api.Models.Group;

namespace Peerly.Gateway.Api.Features.Students.GetStudentGroup;

public sealed record GetStudentGroupQueryResponse
{
    public required GroupInfo GroupInfo { get; init; }
}

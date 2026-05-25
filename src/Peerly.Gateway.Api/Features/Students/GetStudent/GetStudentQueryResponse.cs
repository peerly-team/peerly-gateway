using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Features.Students.GetStudent;

public sealed record GetStudentQueryResponse
{
    public required StudentInfo StudentInfo { get; init; }
}

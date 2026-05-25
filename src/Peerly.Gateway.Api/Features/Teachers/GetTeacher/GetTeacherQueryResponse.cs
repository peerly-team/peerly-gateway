using Peerly.Gateway.Api.Models.Participants;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacher;

public sealed record GetTeacherQueryResponse
{
    public required TeacherInfo TeacherInfo { get; init; }
}

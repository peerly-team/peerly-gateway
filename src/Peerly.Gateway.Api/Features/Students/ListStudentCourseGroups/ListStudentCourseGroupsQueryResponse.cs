using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Group;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseGroups;

public sealed record ListStudentCourseGroupsQueryResponse
{
    public required IReadOnlyCollection<GroupInfo> GroupInfos { get; init; }
}

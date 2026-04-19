using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Group;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseGroups;

public sealed record ListTeacherCourseGroupsQueryResponse
{
    public required IReadOnlyCollection<GroupInfo> GroupInfos { get; init; }
}

using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Course;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseGroups;

public sealed record ListCourseGroupsQueryResponse
{
    public required IReadOnlyCollection<Group> Groups { get; init; }
}

using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseHomeworks;

public sealed record ListCourseHomeworksQueryResponse
{
    public required IReadOnlyCollection<Homework> Homeworks { get; init; }
}

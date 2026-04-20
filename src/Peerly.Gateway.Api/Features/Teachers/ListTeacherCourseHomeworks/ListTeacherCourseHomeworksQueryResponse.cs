using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherCourseHomeworks;

public sealed record ListTeacherCourseHomeworksQueryResponse
{
    public required IReadOnlyCollection<HomeworkInfo> HomeworkInfos { get; init; }
}

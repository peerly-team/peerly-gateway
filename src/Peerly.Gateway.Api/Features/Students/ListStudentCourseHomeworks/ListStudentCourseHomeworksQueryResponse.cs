using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Homeworks;

namespace Peerly.Gateway.Api.Features.Students.ListStudentCourseHomeworks;

public sealed record ListStudentCourseHomeworksQueryResponse
{
    public required IReadOnlyCollection<HomeworkInfo> HomeworkInfos { get; init; }
}

using System.Collections.Generic;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SearchHomeworksFilter
{
    public IReadOnlyList<HomeworkStatus> HomeworkStatuses { get; init; } = new List<HomeworkStatus>();
}

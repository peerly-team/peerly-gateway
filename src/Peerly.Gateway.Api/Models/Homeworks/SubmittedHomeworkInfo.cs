using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Files;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedHomeworkInfo
{
    public required long Id { get; init; }
    public required string Comment { get; init; }
    public required IReadOnlyList<File> Files { get; init; }
}

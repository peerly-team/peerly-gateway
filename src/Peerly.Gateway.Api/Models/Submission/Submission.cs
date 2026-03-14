using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Files;

namespace Peerly.Gateway.Api.Models.Submission;

public sealed record Submission
{
    public required long UserId { get; init; }
    public string? Comment { get; init; }
    public required IReadOnlyCollection<File> Files { get; init; }
}

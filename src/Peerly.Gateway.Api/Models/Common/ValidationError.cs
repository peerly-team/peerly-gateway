using System.Collections.Generic;

namespace Peerly.Gateway.Api.Models.Common;

public sealed record ValidationError
{
    public required string? ErrorDetail { get; set; }
    public required IReadOnlyDictionary<string, string> Extensions { get; init; }
    public required IReadOnlyDictionary<string, string[]> Errors { get; set; }
}

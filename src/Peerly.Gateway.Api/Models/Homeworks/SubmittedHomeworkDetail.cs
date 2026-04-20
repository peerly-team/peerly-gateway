using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Files;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedHomeworkDetail
{
    public required long SubmittedHomeworkId { get; init; }
    public required string Comment { get; init; }
    public required IReadOnlyList<File> Files { get; init; }
    public required IReadOnlyList<Review> Reviews { get; init; }
    public int? FinalMark { get; init; }
}

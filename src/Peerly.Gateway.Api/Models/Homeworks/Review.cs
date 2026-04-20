using System;

namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record Review
{
    public required int Mark { get; init; }
    public required string Comment { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
}

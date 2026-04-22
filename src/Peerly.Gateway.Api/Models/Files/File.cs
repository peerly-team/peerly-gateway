using System;

namespace Peerly.Gateway.Api.Models.Files;

public sealed record File
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}

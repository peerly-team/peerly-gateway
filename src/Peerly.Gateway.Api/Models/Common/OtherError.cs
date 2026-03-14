namespace Peerly.Gateway.Api.Models.Common;

public sealed record OtherError
{
    public required ErrorType Type { get; init; }
    public required string? Message { get; init; }
}

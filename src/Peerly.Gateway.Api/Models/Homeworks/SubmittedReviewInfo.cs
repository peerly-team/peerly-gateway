namespace Peerly.Gateway.Api.Models.Homeworks;

public sealed record SubmittedReviewInfo
{
    public required long Id { get; init; }
    public required int Mark { get; init; }
    public required string Comment { get; init; }
}

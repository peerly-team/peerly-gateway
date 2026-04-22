namespace Peerly.Gateway.Api.Features.Storage.GenerateDownloadUrl;

public sealed record GenerateDownloadUrlQueryResponse
{
    public required string Url { get; init; }
}

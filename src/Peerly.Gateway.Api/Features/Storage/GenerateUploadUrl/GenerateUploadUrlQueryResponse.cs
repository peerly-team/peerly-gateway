namespace Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

public sealed record GenerateUploadUrlQueryResponse
{
    public required string Url { get; init; }
    public required string StorageId { get; init; }
}

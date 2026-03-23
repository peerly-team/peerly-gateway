using MediatR;

namespace Peerly.Gateway.Api.Features.Storage.GenerateDownloadUrl;

public sealed record GenerateDownloadUrlQuery : IRequest<GenerateDownloadUrlQueryResponse>
{
    public required long FileId { get; init; }
}

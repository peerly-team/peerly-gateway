using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateDownloadUrl;

public sealed class GenerateDownloadUrlHandler : FeatureHandlerAdapter<
    GenerateDownloadUrlQuery, GenerateDownloadUrlQueryResponse, V1GenerateDownloadUrlRequest, V1GenerateDownloadUrlResponse>
{
    public GenerateDownloadUrlHandler(StorageService.StorageServiceClient client, IMapper mapper)
        : base(client.V1GenerateDownloadUrlAsync, mapper)
    {
    }
}

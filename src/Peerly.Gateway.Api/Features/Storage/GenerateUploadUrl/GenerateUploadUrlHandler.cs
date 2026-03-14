using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

public sealed class GenerateUploadUrlHandler : FeatureHandlerAdapter<
    GenerateUploadUrlQuery, GenerateUploadUrlQueryResponse, V1GenerateUploadUrlRequest, V1GenerateUploadUrlResponse>
{
    public GenerateUploadUrlHandler(StorageService.StorageServiceClient client, IMapper mapper)
        : base(client.V1GenerateUploadUrlAsync, mapper)
    {
    }
}

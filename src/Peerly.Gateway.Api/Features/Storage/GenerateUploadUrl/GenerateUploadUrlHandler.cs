using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

public sealed class GenerateUploadUrlHandler : FeatureHandlerAdapter<
    GenerateUploadUrlQuery, GenerateUploadUrlQueryResponse, GenerateUploadUrlRequest, GenerateUploadUrlResponse>
{
    public GenerateUploadUrlHandler(StorageService.StorageServiceClient client, IMapper mapper)
        : base(client.GenerateUploadUrlAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateDownloadUrl;

public sealed class GenerateDownloadUrlProfile : Profile
{
    public GenerateDownloadUrlProfile()
    {
        CreateMap<GenerateDownloadUrlQuery, V1GenerateDownloadUrlRequest>();
        CreateMap<V1GenerateDownloadUrlResponse, GenerateDownloadUrlQueryResponse>();
    }
}

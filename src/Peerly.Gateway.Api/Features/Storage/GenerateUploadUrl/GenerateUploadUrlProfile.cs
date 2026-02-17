using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

public sealed class GenerateUploadUrlProfile : Profile
{
    public GenerateUploadUrlProfile()
    {
        CreateMap<GenerateUploadUrlQuery, V1GenerateUploadUrlRequest>();
        CreateMap<V1GenerateUploadUrlResponse, GenerateUploadUrlQueryResponse>();
    }
}

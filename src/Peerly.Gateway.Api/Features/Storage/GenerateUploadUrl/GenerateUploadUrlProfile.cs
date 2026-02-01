using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

public sealed class GenerateUploadUrlProfile : Profile
{
    public GenerateUploadUrlProfile()
    {
        CreateMap<GenerateUploadUrlQuery, GenerateUploadUrlRequest>();
        CreateMap<GenerateUploadUrlResponse, GenerateUploadUrlQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Storage.GenerateDownloadUrl;

public sealed class GenerateDownloadUrlProfile : Profile
{
    public GenerateDownloadUrlProfile()
    {
        CreateMap<GenerateDownloadUrlQuery, V1GenerateDownloadUrlRequest>()
            .ForMember(dst => dst.IsReviewer, opt => opt.Ignore());
        CreateMap<V1GenerateDownloadUrlResponse, GenerateDownloadUrlQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteHomeworkFile;

public sealed class DeleteHomeworkFileProfile : Profile
{
    public DeleteHomeworkFileProfile()
    {
        CreateMap<DeleteHomeworkFileCommand, V1DeleteHomeworkFileRequest>();
        CreateMap<V1DeleteHomeworkFileResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteHomeworkFileResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

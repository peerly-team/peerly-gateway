using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteHomework;

public sealed class DeleteHomeworkProfile : Profile
{
    public DeleteHomeworkProfile()
    {
        CreateMap<DeleteHomeworkCommand, V1DeleteHomeworkRequest>();
        CreateMap<V1DeleteHomeworkResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteHomeworkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.PublishHomework;

public sealed class PublishHomeworkProfile : Profile
{
    public PublishHomeworkProfile()
    {
        CreateMap<PublishHomeworkCommand, V1PublishHomeworkRequest>();
        CreateMap<V1PublishHomeworkResponse, Result<EmptyResponse>>();
        CreateMap<V1PublishHomeworkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

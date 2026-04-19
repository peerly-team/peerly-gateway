using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.ConfirmHomework;

public sealed class ConfirmHomeworkProfile : Profile
{
    public ConfirmHomeworkProfile()
    {
        CreateMap<ConfirmHomeworkCommand, V1ConfirmHomeworkRequest>();
        CreateMap<V1ConfirmHomeworkResponse, Result<EmptyResponse>>();
        CreateMap<V1ConfirmHomeworkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

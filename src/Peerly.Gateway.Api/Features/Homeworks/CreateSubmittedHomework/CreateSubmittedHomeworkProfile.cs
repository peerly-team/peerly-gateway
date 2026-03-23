using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomework;

public sealed class CreateSubmittedHomeworkProfile : Profile
{
    public CreateSubmittedHomeworkProfile()
    {
        CreateMap<CreateSubmittedHomeworkCommand, V1CreateSubmittedHomeworkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateSubmittedHomeworkRequestBody, V1CreateSubmittedHomeworkRequest>();
        CreateMap<V1CreateSubmittedHomeworkResponse, Result<CreateSubmittedHomeworkCommandResponse>>();
        CreateMap<V1CreateSubmittedHomeworkResponse.Types.Success, CreateSubmittedHomeworkCommandResponse>(MemberList.Source);
    }
}

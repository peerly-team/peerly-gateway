using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateHomeworkFile;

public sealed class CreateHomeworkFileProfile : Profile
{
    public CreateHomeworkFileProfile()
    {
        CreateMap<CreateHomeworkFileCommand, V1CreateHomeworkFileRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateHomeworkFileRequestBody, V1CreateHomeworkFileRequest>();
        CreateMap<V1CreateHomeworkFileResponse, Result<CreateHomeworkFileCommandResponse>>();
        CreateMap<V1CreateHomeworkFileResponse.Types.Success, CreateHomeworkFileCommandResponse>(MemberList.Source);
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.CreateSubmittedHomeworkFile;

public sealed class CreateSubmittedHomeworkFileProfile : Profile
{
    public CreateSubmittedHomeworkFileProfile()
    {
        CreateMap<CreateSubmittedHomeworkFileCommand, V1CreateSubmittedHomeworkFileRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateSubmittedHomeworkFileRequestBody, V1CreateSubmittedHomeworkFileRequest>();
        CreateMap<V1CreateSubmittedHomeworkFileResponse, Result<CreateSubmittedHomeworkFileCommandResponse>>();
        CreateMap<V1CreateSubmittedHomeworkFileResponse.Types.Success, CreateSubmittedHomeworkFileCommandResponse>(MemberList.Source);
    }
}

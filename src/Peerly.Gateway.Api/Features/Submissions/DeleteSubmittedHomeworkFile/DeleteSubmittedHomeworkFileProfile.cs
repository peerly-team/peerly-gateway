using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.DeleteSubmittedHomeworkFile;

public sealed class DeleteSubmittedHomeworkFileProfile : Profile
{
    public DeleteSubmittedHomeworkFileProfile()
    {
        CreateMap<DeleteSubmittedHomeworkFileCommand, V1DeleteSubmittedHomeworkFileRequest>();
        CreateMap<V1DeleteSubmittedHomeworkFileResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteSubmittedHomeworkFileResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

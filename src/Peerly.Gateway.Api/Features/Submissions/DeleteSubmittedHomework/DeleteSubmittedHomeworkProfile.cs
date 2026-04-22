using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.DeleteSubmittedHomework;

public sealed class DeleteSubmittedHomeworkProfile : Profile
{
    public DeleteSubmittedHomeworkProfile()
    {
        CreateMap<DeleteSubmittedHomeworkCommand, V1DeleteSubmittedHomeworkRequest>();
        CreateMap<V1DeleteSubmittedHomeworkResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteSubmittedHomeworkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

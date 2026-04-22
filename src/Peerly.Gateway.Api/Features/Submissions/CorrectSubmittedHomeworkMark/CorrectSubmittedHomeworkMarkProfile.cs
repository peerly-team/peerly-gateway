using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.CorrectSubmittedHomeworkMark;

public sealed class CorrectSubmittedHomeworkMarkProfile : Profile
{
    public CorrectSubmittedHomeworkMarkProfile()
    {
        CreateMap<CorrectSubmittedHomeworkMarkCommand, V1CorrectSubmittedHomeworkMarkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CorrectSubmittedHomeworkMarkRequestBody, V1CorrectSubmittedHomeworkMarkRequest>();
        CreateMap<V1CorrectSubmittedHomeworkMarkResponse, Result<EmptyResponse>>();
        CreateMap<V1CorrectSubmittedHomeworkMarkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CorrectSubmissionMark;

public sealed class CorrectSubmissionMarkProfile : Profile
{
    public CorrectSubmissionMarkProfile()
    {
        CreateMap<CorrectSubmissionMarkCommand, V1CorrectSubmissionMarkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CorrectSubmissionMarkRequestBody, V1CorrectSubmissionMarkRequest>();
        CreateMap<V1CorrectSubmissionMarkResponse, Result<EmptyResponse>>();
        CreateMap<V1CorrectSubmissionMarkResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

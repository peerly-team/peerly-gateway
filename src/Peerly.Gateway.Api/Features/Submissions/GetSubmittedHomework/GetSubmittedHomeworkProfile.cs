using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Submissions.GetSubmittedHomework;

public sealed class GetSubmittedHomeworkProfile : Profile
{
    public GetSubmittedHomeworkProfile()
    {
        CreateMap<GetSubmittedHomeworkQuery, Proto.V1GetSubmittedHomeworkRequest>();
        CreateMap<Proto.V1GetSubmittedHomeworkResponse, GetSubmittedHomeworkQueryResponse>()
            .ForMember(dst => dst.FinalMark, opt => opt.MapFrom(src => src.HasFinalMark ? (int?)src.FinalMark : null));
        CreateMap<Proto.SubmittedHomeworkInfo, SubmittedHomeworkInfo>();
    }
}

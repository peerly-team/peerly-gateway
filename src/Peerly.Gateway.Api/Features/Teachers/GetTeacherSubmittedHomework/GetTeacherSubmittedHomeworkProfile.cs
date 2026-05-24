using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherSubmittedHomework;

public sealed class GetTeacherSubmittedHomeworkProfile : Profile
{
    public GetTeacherSubmittedHomeworkProfile()
    {
        CreateMap<GetTeacherSubmittedHomeworkQuery, Proto.V1GetTeacherSubmittedHomeworkRequest>();
        CreateMap<Proto.V1GetTeacherSubmittedHomeworkResponse, GetTeacherSubmittedHomeworkQueryResponse>()
            .ForMember(dst => dst.ReviewersMark, opt => opt.MapFrom(src => src.HasReviewersMark ? (int?)src.ReviewersMark : null))
            .ForMember(dst => dst.TeacherMark, opt => opt.MapFrom(src => src.HasTeacherMark ? (int?)src.TeacherMark : null));
        CreateMap<Proto.TeacherSubmittedReviewInfo, TeacherSubmittedReviewInfo>();
    }
}

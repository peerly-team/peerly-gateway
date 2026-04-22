using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Submissions.GetAssignedReview;

public sealed class GetAssignedReviewProfile : Profile
{
    public GetAssignedReviewProfile()
    {
        CreateMap<GetAssignedReviewQuery, Proto.V1GetAssignedReviewRequest>();
        CreateMap<Proto.V1GetAssignedReviewResponse, GetAssignedReviewQueryResponse>();
        CreateMap<Proto.V1GetAssignedReviewResponse.Types.SubmissionForReview, SubmissionForReview>()
            .ForMember(dst => dst.SubmittedReviewId,
                opt => opt.MapFrom(src => src.HasSubmittedReviewId ? (long?)src.SubmittedReviewId : null));
    }
}

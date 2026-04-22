using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Reviews.GetSubmittedReview;

public sealed class GetSubmittedReviewProfile : Profile
{
    public GetSubmittedReviewProfile()
    {
        CreateMap<GetSubmittedReviewQuery, V1GetSubmittedReviewRequest>();
        CreateMap<V1GetSubmittedReviewResponse, GetSubmittedReviewQueryResponse>();
    }
}

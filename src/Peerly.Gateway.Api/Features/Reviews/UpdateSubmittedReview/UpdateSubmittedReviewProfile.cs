using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Reviews.UpdateSubmittedReview;

public sealed class UpdateSubmittedReviewProfile : Profile
{
    public UpdateSubmittedReviewProfile()
    {
        CreateMap<UpdateSubmittedReviewCommand, V1UpdateSubmittedReviewRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateSubmittedReviewRequestBody, V1UpdateSubmittedReviewRequest>();
        CreateMap<V1UpdateSubmittedReviewResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateSubmittedReviewResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

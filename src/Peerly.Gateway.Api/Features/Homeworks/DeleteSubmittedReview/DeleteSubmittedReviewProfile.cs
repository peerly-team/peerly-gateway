using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteSubmittedReview;

public sealed class DeleteSubmittedReviewProfile : Profile
{
    public DeleteSubmittedReviewProfile()
    {
        CreateMap<DeleteSubmittedReviewCommand, V1DeleteSubmittedReviewRequest>();
        CreateMap<V1DeleteSubmittedReviewResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteSubmittedReviewResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

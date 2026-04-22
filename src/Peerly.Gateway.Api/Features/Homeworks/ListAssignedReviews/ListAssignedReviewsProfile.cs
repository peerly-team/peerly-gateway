using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.ListAssignedReviews;

public sealed class ListAssignedReviewsProfile : Profile
{
    public ListAssignedReviewsProfile()
    {
        CreateMap<ListAssignedReviewsQuery, Proto.V1ListAssignedReviewsRequest>();
        CreateMap<Proto.V1ListAssignedReviewsResponse, ListAssignedReviewsQueryResponse>();
        CreateMap<Proto.V1ListAssignedReviewsResponse.Types.AssignedReview, AssignedReviewInfo>();
    }
}

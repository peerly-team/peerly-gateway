using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.CreateSubmittedReview;

public sealed class CreateSubmittedReviewProfile : Profile
{
    public CreateSubmittedReviewProfile()
    {
        CreateMap<CreateSubmittedReviewCommand, V1CreateSubmittedReviewRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateSubmittedReviewRequestBody, V1CreateSubmittedReviewRequest>();
        CreateMap<V1CreateSubmittedReviewResponse, Result<CreateSubmittedReviewCommandResponse>>();
        CreateMap<V1CreateSubmittedReviewResponse.Types.Success, CreateSubmittedReviewCommandResponse>(MemberList.Source);
    }
}

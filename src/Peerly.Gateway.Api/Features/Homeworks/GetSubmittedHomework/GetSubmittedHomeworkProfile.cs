using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.GetSubmittedHomework;

public sealed class GetSubmittedHomeworkProfile : Profile
{
    public GetSubmittedHomeworkProfile()
    {
        CreateMap<GetSubmittedHomeworkQuery, Proto.V1GetSubmittedHomeworkRequest>();
        CreateMap<Proto.V1GetSubmittedHomeworkResponse, GetSubmittedHomeworkQueryResponse>();
        CreateMap<Proto.V1GetSubmittedHomeworkResponse.Types.SubmissionDetail, SubmittedHomeworkDetail>();
        CreateMap<Proto.V1GetSubmittedHomeworkResponse.Types.Review, Review>();
    }
}

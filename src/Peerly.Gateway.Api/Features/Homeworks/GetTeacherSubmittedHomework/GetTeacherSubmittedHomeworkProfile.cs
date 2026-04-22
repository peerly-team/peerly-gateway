using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.GetTeacherSubmittedHomework;

public sealed class GetTeacherSubmittedHomeworkProfile : Profile
{
    public GetTeacherSubmittedHomeworkProfile()
    {
        CreateMap<GetTeacherSubmittedHomeworkQuery, Proto.V1GetTeacherSubmittedHomeworkRequest>();
        CreateMap<Proto.V1GetTeacherSubmittedHomeworkResponse, GetTeacherSubmittedHomeworkQueryResponse>();
        CreateMap<Proto.TeacherSubmittedReviewInfo, TeacherSubmittedReviewInfo>();
    }
}

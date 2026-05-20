using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentHomework;

public sealed class GetStudentHomeworkProfile : Profile
{
    public GetStudentHomeworkProfile()
    {
        CreateMap<GetStudentHomeworkQuery, Proto.V1GetStudentHomeworkRequest>();
        CreateMap<Proto.V1GetStudentHomeworkResponse, GetStudentHomeworkQueryResponse>()
            .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.HomeworkFiles))
            .ForMember(dst => dst.SubmittedHomeworkId,
                opt => opt.MapFrom(src => src.HasSubmittedHomeworkId ? src.SubmittedHomeworkId : (long?)null));
    }
}

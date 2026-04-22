using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherHomework;

public sealed class GetTeacherHomeworkProfile : Profile
{
    public GetTeacherHomeworkProfile()
    {
        CreateMap<GetTeacherHomeworkQuery, Proto.V1GetTeacherHomeworkRequest>();
        CreateMap<Proto.V1GetTeacherHomeworkResponse, GetTeacherHomeworkQueryResponse>();
    }
}

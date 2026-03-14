using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherCourse;

public sealed class GetTeacherCourseProfile : Profile
{
    public GetTeacherCourseProfile()
    {
        CreateMap<GetTeacherCourseQuery, Proto.V1GetTeacherCourseRequest>();
        CreateMap<Proto.V1GetTeacherCourseResponse, GetTeacherCourseQueryResponse>();
    }
}


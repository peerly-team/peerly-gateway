using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Student.GetStudentCourse;

public sealed class GetStudentCourseProfile : Profile
{
    public GetStudentCourseProfile()
    {
        CreateMap<GetStudentCourseQuery, Proto.V1GetStudentCourseRequest>();
        CreateMap<Proto.V1GetStudentCourseResponse, GetStudentCourseQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourse;

public sealed class CreateCourseProfile : Profile
{
    public CreateCourseProfile()
    {
        CreateMap<CreateCourseCommand, V1CreateCourseRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateCourseRequestBody, V1CreateCourseRequest>();
        CreateMap<V1CreateCourseResponse, Result<CreateCourseCommandResponse>>();
        CreateMap<V1CreateCourseResponse.Types.Success, CreateCourseCommandResponse>(MemberList.Source);
    }
}

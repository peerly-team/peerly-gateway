using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.UpdateCourse;

public sealed class UpdateCourseProfile : Profile
{
    public UpdateCourseProfile()
    {
        CreateMap<UpdateCourseCommand, V1UpdateCourseRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateCourseRequestBody, V1UpdateCourseRequest>();
        CreateMap<V1UpdateCourseResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateCourseResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.DeleteCourse;

public sealed class DeleteCourseProfile : Profile
{
    public DeleteCourseProfile()
    {
        CreateMap<DeleteCourseCommand, V1DeleteCourseRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<DeleteCourseRequestBody, V1DeleteCourseRequest>();
        CreateMap<V1DeleteCourseResponse, Result<EmptyResponse>>();
        CreateMap<V1DeleteCourseResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

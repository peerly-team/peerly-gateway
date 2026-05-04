using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.PublishCourse;

public sealed class PublishCourseProfile : Profile
{
    public PublishCourseProfile()
    {
        CreateMap<PublishCourseCommand, V1PublishCourseRequest>();
        CreateMap<V1PublishCourseResponse, Result<EmptyResponse>>();
        CreateMap<V1PublishCourseResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

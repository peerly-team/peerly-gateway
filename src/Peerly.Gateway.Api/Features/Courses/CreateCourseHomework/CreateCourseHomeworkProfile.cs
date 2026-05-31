using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourseHomework;

public sealed class CreateCourseHomeworkProfile : Profile
{
    public CreateCourseHomeworkProfile()
    {
        CreateMap<CreateCourseHomeworkCommand, V1CreateCourseHomeworkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateCourseHomeworkRequestBody, V1CreateCourseHomeworkRequest>(MemberList.Source)
            .ForMember(dst => dst.RubricId, opt => opt.Condition(src => src.RubricId.HasValue));
        CreateMap<V1CreateCourseHomeworkResponse, Result<CreateCourseHomeworkCommandResponse>>();
        CreateMap<V1CreateCourseHomeworkResponse.Types.Success, CreateCourseHomeworkCommandResponse>(MemberList.Source);
    }
}

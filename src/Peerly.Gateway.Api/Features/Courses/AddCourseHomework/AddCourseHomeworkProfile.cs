using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.AddCourseHomework;

public sealed class AddCourseHomeworkProfile : Profile
{
    public AddCourseHomeworkProfile()
    {
        CreateMap<AddCourseHomeworkCommand, V1CreateHomeworkRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<AddCourseHomeworkRequestBody, V1CreateHomeworkRequest>();
        CreateMap<V1CreateHomeworkResponse, Result<AddCourseHomeworkCommandResponse>>();
        CreateMap<V1CreateHomeworkResponse.Types.Success, AddCourseHomeworkCommandResponse>(MemberList.Source);
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Courses.CreateCourseFile;

public sealed class CreateCourseFileProfile : Profile
{
    public CreateCourseFileProfile()
    {
        CreateMap<CreateCourseFileCommand, V1CreateCourseFileRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<CreateCourseFileRequestBody, V1CreateCourseFileRequest>();
        CreateMap<V1CreateCourseFileResponse, Result<CreateCourseFileCommandResponse>>();
        CreateMap<V1CreateCourseFileResponse.Types.Success, CreateCourseFileCommandResponse>(MemberList.Source);
    }
}

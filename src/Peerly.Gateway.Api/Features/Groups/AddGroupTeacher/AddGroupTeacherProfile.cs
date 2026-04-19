using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupTeacher;

public sealed class AddGroupTeacherProfile : Profile
{
    public AddGroupTeacherProfile()
    {
        CreateMap<AddGroupTeacherCommand, V1AddGroupTeacherRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<AddGroupTeacherRequestBody, V1AddGroupTeacherRequest>();
        CreateMap<V1AddGroupTeacherResponse, Result<EmptyResponse>>();
        CreateMap<V1AddGroupTeacherResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Teachers.UpdateTeacher;

public sealed class UpdateTeacherProfile : Profile
{
    public UpdateTeacherProfile()
    {
        CreateMap<UpdateTeacherCommand, V1UpdateTeacherRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateTeacherRequestBody, V1UpdateTeacherRequest>(MemberList.Source);
        CreateMap<V1UpdateTeacherResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateTeacherResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

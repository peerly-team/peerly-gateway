using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupStudent;

public sealed class AddGroupStudentProfile : Profile
{
    public AddGroupStudentProfile()
    {
        CreateMap<AddGroupStudentCommand, V1AddGroupStudentRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<AddGroupStudentRequestBody, V1AddGroupStudentRequest>();
        CreateMap<V1AddGroupStudentResponse, Result<EmptyResponse>>();
        CreateMap<V1AddGroupStudentResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

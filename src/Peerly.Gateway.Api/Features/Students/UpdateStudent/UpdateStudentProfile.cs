using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Students.UpdateStudent;

public sealed class UpdateStudentProfile : Profile
{
    public UpdateStudentProfile()
    {
        CreateMap<UpdateStudentCommand, V1UpdateStudentRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<UpdateStudentRequestBody, V1UpdateStudentRequest>(MemberList.Source);
        CreateMap<V1UpdateStudentResponse, Result<EmptyResponse>>();
        CreateMap<V1UpdateStudentResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

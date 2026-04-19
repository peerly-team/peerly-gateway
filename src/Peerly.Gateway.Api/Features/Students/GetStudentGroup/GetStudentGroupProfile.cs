using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentGroup;

public sealed class GetStudentGroupProfile : Profile
{
    public GetStudentGroupProfile()
    {
        CreateMap<GetStudentGroupQuery, Proto.V1GetStudentGroupRequest>();
        CreateMap<Proto.V1GetStudentGroupResponse, GetStudentGroupQueryResponse>();
    }
}

using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Extensions;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.BulkAddGroupStudents;

public sealed class BulkAddGroupStudentsProfile : Profile
{
    public BulkAddGroupStudentsProfile()
    {
        CreateMap<BulkAddGroupStudentsCommand, V1BulkAddGroupStudentsRequest>()
            .IncludeMembers(c => c.RequestBody);
        CreateMap<BulkAddGroupStudentsRequestBody, V1BulkAddGroupStudentsRequest>(MemberList.Source);
        CreateMap<V1BulkAddGroupStudentsResponse, Result<BulkAddGroupStudentsCommandResponse>>();
        CreateMap<V1BulkAddGroupStudentsResponse.Types.Success, BulkAddGroupStudentsCommandResponse>();
        CreateMap<V1BulkAddGroupStudentsResponse.Types.SkippedStudentInfo, BulkAddGroupStudentsSkippedStudentInfo>();
        CreateMap<V1BulkAddGroupStudentsResponse.Types.SkipReason, BulkAddGroupStudentsSkipReason>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(V1BulkAddGroupStudentsResponse.Types.SkipReason.Unspecified));
    }
}

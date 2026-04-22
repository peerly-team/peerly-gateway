using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;

public sealed class ListCourseParticipantsProfile : Profile
{
    public ListCourseParticipantsProfile()
    {
        CreateMap<ListCourseParticipantsQuery, Proto.V1ListCourseParticipantsRequest>();
        CreateMap<Proto.V1ListCourseParticipantsResponse, ListCourseParticipantsQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Courses.ListCourseParticipants;

public sealed class ListCourseParticipantsHandler : FeatureHandlerAdapter<
    ListCourseParticipantsQuery, ListCourseParticipantsQueryResponse, V1ListCourseParticipantsRequest, V1ListCourseParticipantsResponse>
{
    public ListCourseParticipantsHandler(ParticipantService.ParticipantServiceClient client, IMapper mapper)
        : base(client.V1ListCourseParticipantsAsync, mapper)
    {
    }
}

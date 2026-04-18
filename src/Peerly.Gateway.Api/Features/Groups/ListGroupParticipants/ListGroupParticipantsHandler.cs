using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;

public sealed class ListGroupParticipantsHandler : FeatureHandlerAdapter<
    ListGroupParticipantsQuery, ListGroupParticipantsQueryResponse, V1ListGroupParticipantsRequest, V1ListGroupParticipantsResponse>
{
    public ListGroupParticipantsHandler(ParticipantService.ParticipantServiceClient client, IMapper mapper)
        : base(client.V1ListGroupParticipantsAsync, mapper)
    {
    }
}

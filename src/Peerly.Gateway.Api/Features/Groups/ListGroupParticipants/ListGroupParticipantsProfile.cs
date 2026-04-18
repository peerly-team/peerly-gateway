using AutoMapper;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Groups.ListGroupParticipants;

public sealed class ListGroupParticipantsProfile : Profile
{
    public ListGroupParticipantsProfile()
    {
        CreateMap<ListGroupParticipantsQuery, Proto.V1ListGroupParticipantsRequest>();
        CreateMap<Proto.V1ListGroupParticipantsResponse, ListGroupParticipantsQueryResponse>();
    }
}

using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupStudent;

public sealed class AddGroupStudentHandler : FeatureHandlerAdapter<
    AddGroupStudentCommand, Result<EmptyResponse>,
    V1AddGroupStudentRequest, V1AddGroupStudentResponse>
{
    public AddGroupStudentHandler(
        ParticipantService.ParticipantServiceClient client,
        IMapper mapper)
        : base(client.V1AddGroupStudentAsync, mapper)
    {
    }
}

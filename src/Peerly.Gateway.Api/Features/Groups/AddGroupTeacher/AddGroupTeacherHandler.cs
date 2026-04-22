using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.AddGroupTeacher;

public sealed class AddGroupTeacherHandler :
    FeatureHandlerAdapter<AddGroupTeacherCommand, Result<EmptyResponse>, V1AddGroupTeacherRequest, V1AddGroupTeacherResponse>
{
    public AddGroupTeacherHandler(
        ParticipantService.ParticipantServiceClient client,
        IMapper mapper)
        : base(client.V1AddGroupTeacherAsync, mapper)
    {
    }
}

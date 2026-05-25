using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Students.UpdateStudent;

public sealed class UpdateStudentHandler : FeatureHandlerAdapter<
    UpdateStudentCommand, Result<EmptyResponse>, V1UpdateStudentRequest, V1UpdateStudentResponse>
{
    public UpdateStudentHandler(UserService.UserServiceClient client, IMapper mapper)
        : base(client.V1UpdateStudentAsync, mapper)
    {
    }
}

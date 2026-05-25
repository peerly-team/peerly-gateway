using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Teachers.UpdateTeacher;

public sealed class UpdateTeacherHandler : FeatureHandlerAdapter<UpdateTeacherCommand, Result<EmptyResponse>, V1UpdateTeacherRequest, V1UpdateTeacherResponse>
{
    public UpdateTeacherHandler(UserService.UserServiceClient client, IMapper mapper)
        : base(client.V1UpdateTeacherAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacher;

public sealed class GetTeacherHandler : FeatureHandlerAdapter<GetTeacherQuery, GetTeacherQueryResponse, V1GetTeacherRequest, V1GetTeacherResponse>
{
    public GetTeacherHandler(UserService.UserServiceClient client, IMapper mapper)
        : base(client.V1GetTeacherAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudent;

public sealed class GetStudentHandler : FeatureHandlerAdapter<GetStudentQuery, GetStudentQueryResponse, V1GetStudentRequest, V1GetStudentResponse>
{
    public GetStudentHandler(UserService.UserServiceClient client, IMapper mapper)
        : base(client.V1GetStudentAsync, mapper)
    {
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Users.SearchUsers;

public sealed class SearchUsersHandler : FeatureHandlerAdapter<
    SearchUsersQuery, SearchUsersQueryResponse, V1SearchUsersRequest, V1SearchUsersResponse>
{
    public SearchUsersHandler(UserService.UserServiceClient client, IMapper mapper)
        : base(client.V1SearchUsersAsync, mapper)
    {
    }
}

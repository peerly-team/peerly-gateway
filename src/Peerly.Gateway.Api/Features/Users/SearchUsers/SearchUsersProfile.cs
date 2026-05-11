using AutoMapper;
using Peerly.Gateway.Api.Models.Users;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Users.SearchUsers;

public sealed class SearchUsersProfile : Profile
{
    public SearchUsersProfile()
    {
        CreateMap<SearchUsersFilter, Proto.V1SearchUsersRequest.Types.SearchUsersFilter>();
        CreateMap<SearchUsersQuery, Proto.V1SearchUsersRequest>();
        CreateMap<Proto.V1SearchUsersResponse.Types.UserInfo, UserInfo>();
        CreateMap<Proto.V1SearchUsersResponse, SearchUsersQueryResponse>();
    }
}

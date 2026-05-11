using System.Collections.Generic;
using Peerly.Gateway.Api.Models.Users;

namespace Peerly.Gateway.Api.Features.Users.SearchUsers;

public sealed class SearchUsersQueryResponse
{
    public required IReadOnlyCollection<UserInfo> Users { get; init; }
}

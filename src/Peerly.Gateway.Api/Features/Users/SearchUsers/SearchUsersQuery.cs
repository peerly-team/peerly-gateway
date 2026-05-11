using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Auth;

namespace Peerly.Gateway.Api.Features.Users.SearchUsers;

public sealed record SearchUsersFilter
{
    public IReadOnlyList<Role> Roles { get; init; } = new List<Role>();
    public string Query { get; init; } = string.Empty;
}

public sealed record SearchUsersQuery : IRequest<SearchUsersQueryResponse>
{
    public required SearchUsersFilter Filter { get; init; }
    public required int Limit { get; init; }
}

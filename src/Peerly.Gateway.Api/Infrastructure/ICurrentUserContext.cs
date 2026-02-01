using System.Collections.Generic;

namespace Peerly.Gateway.Api.Infrastructure;

public interface ICurrentUserContext
{
    bool IsAuthenticated { get; }
    string? UserName { get; }
    IReadOnlyCollection<string> Roles { get; }
}

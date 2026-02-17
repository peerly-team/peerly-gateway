using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks.Abstractions;

public interface IJwksProvider
{
    Task<IReadOnlyList<SecurityKey>> GetAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<SecurityKey>> RefreshJwksAsync(CancellationToken cancellationToken);
}

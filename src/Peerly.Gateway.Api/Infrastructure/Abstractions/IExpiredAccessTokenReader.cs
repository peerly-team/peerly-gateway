using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Peerly.Gateway.Api.Infrastructure.Abstractions;

public interface IExpiredAccessTokenReader
{
    Task<long?> TryGetUserIdAsync(HttpRequest request, CancellationToken cancellationToken);
}

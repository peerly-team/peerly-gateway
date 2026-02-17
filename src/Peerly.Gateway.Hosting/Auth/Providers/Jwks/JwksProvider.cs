using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Abstractions;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Models;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Options;
using Peerly.Gateway.Tools;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks;

internal sealed class JwksProvider : IJwksProvider
{
    private const string JwksCacheName = "jwks";

    private readonly IMemoryCache _cache;
    private readonly IMediator _mediator;
    private readonly JwksProviderOptions _options;
    private readonly TimeSpan _cacheLifeTime;

    public JwksProvider(
        IMemoryCache cache,
        IMediator mediator,
        IOptionsSnapshot<JwksProviderOptions> options)
    {
        _cache = cache;
        _mediator = mediator;
        _options = options.Value;
        _cacheLifeTime = TimeSpan.FromSeconds(_options.CacheLifetimeInSeconds);
    }

    public Task<IReadOnlyList<SecurityKey>> GetAsync(CancellationToken cancellationToken) => _cache.GetOrCreateAsync(
        JwksCacheName,
        async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheLifeTime);
            entry.SetSize(_options.CacheSize);
            return await LoadKeysAsync(cancellationToken);
        })!;

    public async Task<IReadOnlyList<SecurityKey>> RefreshJwksAsync(CancellationToken cancellationToken)
    {
        var keys = await LoadKeysAsync(cancellationToken);
        _cache.Set(JwksCacheName, keys, _cacheLifeTime);
        return keys;
    }

    private async Task<IReadOnlyList<SecurityKey>> LoadKeysAsync(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetJwksQuery
        {
            Issuer = "peerly-gateway"
        }, cancellationToken: cancellationToken);

        var keys = response.Jwks
            .ToArrayBy(jwksJson => (SecurityKey)new JsonWebKey(jwksJson));

        return keys;
    }
}

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks.Options;

internal sealed record JwksProviderOptions
{
    public const string SectionName = "JwksProviderOptions";

    private const int DefaultCacheLifetimeInSeconds = 600;
    private const int DefaultCacheSize = 128;

    public int CacheLifetimeInSeconds { get; set; } = DefaultCacheLifetimeInSeconds;
    public int CacheSize { get; set; } = DefaultCacheSize;
}

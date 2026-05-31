using System.Collections.Generic;

namespace Peerly.Gateway.ExternalClients.ServiceVersions;

internal sealed class ServiceVersionContext : IServiceVersionContext
{
    private static readonly IReadOnlyDictionary<string, string> Empty =
        new Dictionary<string, string>(0);

    public IReadOnlyDictionary<string, string> Overrides { get; private set; } = Empty;

    public void Set(IReadOnlyDictionary<string, string> overrides) =>
        Overrides = overrides;
}

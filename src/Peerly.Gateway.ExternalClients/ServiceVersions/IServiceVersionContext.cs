using System.Collections.Generic;

namespace Peerly.Gateway.ExternalClients.ServiceVersions;

public interface IServiceVersionContext
{
    IReadOnlyDictionary<string, string> Overrides { get; }
    void Set(IReadOnlyDictionary<string, string> overrides);
}

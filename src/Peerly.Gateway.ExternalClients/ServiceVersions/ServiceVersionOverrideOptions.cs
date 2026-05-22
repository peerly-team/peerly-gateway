using System.Collections.Generic;

namespace Peerly.Gateway.ExternalClients.ServiceVersions;

internal sealed class ServiceVersionOverrideOptions
{
    public const string SectionName = "ServiceVersionOverrides";

    public bool Enabled { get; init; }

    public Dictionary<string, string> DnsTemplates { get; init; } = new();
}

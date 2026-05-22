using Microsoft.Extensions.Options;

namespace Peerly.Gateway.ExternalClients.ServiceVersions;

internal interface IServiceVersionResolver
{
    string Resolve(string serviceName, string defaultTarget);
}

internal sealed class ServiceVersionResolver(
    IOptionsMonitor<ServiceVersionOverrideOptions> options,
    IServiceVersionContext context) : IServiceVersionResolver
{
    public string Resolve(string serviceName, string defaultTarget)
    {
        var opts = options.CurrentValue;
        if (!opts.Enabled)
            return defaultTarget;

        if (!context.Overrides.TryGetValue(serviceName, out var tag) || string.IsNullOrWhiteSpace(tag))
            return defaultTarget;

        if (!opts.DnsTemplates.TryGetValue(serviceName, out var template) || string.IsNullOrWhiteSpace(template))
            return defaultTarget;

        return template.Replace("{tag}", tag);
    }
}

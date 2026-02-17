using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Abstractions;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.Hosting.Auth.Providers.Jwks;

internal sealed class JwksProviderInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        services.AddScoped<IJwksProvider, JwksProvider>();
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Peerly.Gateway.Tools.Abstractions;

public interface IInstaller
{
    void InstallServices(IServiceCollection services);
}

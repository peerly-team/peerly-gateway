using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Peerly.Gateway.Tools.Abstractions;

public interface IConfigurableInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}

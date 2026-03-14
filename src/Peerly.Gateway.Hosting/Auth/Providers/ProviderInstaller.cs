using System.Diagnostics.CodeAnalysis;
using AutoMapper.Extensions.EnumMapping;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Hosting.Auth.Providers.Jwks.Models;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.Hosting.Auth.Providers;

[ExcludeFromCodeCoverage]
internal sealed class ProviderInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        services.AddAutoMapper(
            config =>
            {
                config.EnableEnumMappingValidation();
                config.AddMaps(typeof(GetJwksProfile).Assembly);
            });
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<GetJwksHandler>();
        });
    }
}

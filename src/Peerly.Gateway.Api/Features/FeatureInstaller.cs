using System.Diagnostics.CodeAnalysis;
using AutoMapper.Extensions.EnumMapping;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.Api.Features;

[ExcludeFromCodeCoverage]
internal sealed class FeatureInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        // TODO: уйти от AutoMapper (в v12 CVE-2026-32933, начиная с v15 — коммерческий). Кандидат на замену — Mapperly.
        services.AddAutoMapper(
            config =>
            {
                config.EnableEnumMappingValidation();
                config.AddMaps(typeof(GenerateUploadUrlProfile).Assembly);
            });
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<GenerateUploadUrlHandler>();
        });
    }
}

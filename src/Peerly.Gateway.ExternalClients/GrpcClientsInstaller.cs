using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Auth.V1;
using Peerly.Core.V1;
using Peerly.Gateway.ExternalClients.Extensions;
using Peerly.Gateway.ExternalClients.Options;
using Peerly.Gateway.ExternalClients.ServiceVersions;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.ExternalClients;

[ExcludeFromCodeCoverage]
internal sealed class GrpcClientsInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        services
            .AddOptions<PeerlyAuthGrpcClientOptions>()
            .BindConfiguration(PeerlyAuthGrpcClientOptions.SectionName);
        services
            .AddOptions<PeerlyCoreGrpcClientOptions>()
            .BindConfiguration(PeerlyCoreGrpcClientOptions.SectionName);
        services
            .AddOptions<ServiceVersionOverrideOptions>()
            .BindConfiguration(ServiceVersionOverrideOptions.SectionName);

        services.AddHttpContextAccessor();
        services.AddScoped<IServiceVersionContext, ServiceVersionContext>();
        services.AddScoped<IServiceVersionResolver, ServiceVersionResolver>();
        services.AddSingleton<IGrpcChannelPool, GrpcChannelPool>();
        services.AddSingleton<HeaderPropagationInterceptor>();

        AddPeerlyCoreGrpcClients(services);
        AddPeerlyAuthGrpcClients(services);
    }

    private static void AddPeerlyCoreGrpcClients(IServiceCollection services)
    {
        services.AddPeerlyCoreGrpcClient<StorageService.StorageServiceClient>();
        services.AddPeerlyCoreGrpcClient<CourseService.CourseServiceClient>();
        services.AddPeerlyCoreGrpcClient<HomeworkService.HomeworkServiceClient>();
        services.AddPeerlyCoreGrpcClient<SubmissionService.SubmissionServiceClient>();
        services.AddPeerlyCoreGrpcClient<ParticipantService.ParticipantServiceClient>();
        services.AddPeerlyCoreGrpcClient<GroupService.GroupServiceClient>();
    }

    private static void AddPeerlyAuthGrpcClients(IServiceCollection services)
    {
        services.AddPeerlyAuthGrpcClient<AuthService.AuthServiceClient>();
    }
}

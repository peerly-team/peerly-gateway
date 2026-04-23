using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Extensions;
using Peerly.Gateway.ExternalClients.Extensions;
using Peerly.Gateway.Hosting.Extensions;
using Peerly.Gateway.Hosting.Middlewares;
using Peerly.Gateway.Tools;

namespace Peerly.Gateway.Hosting;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Hosting
        builder.Services.InstallServicesFromExecutingAssembly(builder.Configuration);

        builder.Services.AddCors();

        // ExternalClients
        builder.Services.ConfigureExternalClientsServices(builder.Configuration);

        // Grpc
        builder.Services.AddGrpc(o => { o.EnableDetailedErrors = true; });
        builder.Services.AddGrpcReflection();

        // Error handling
        builder.Services
            .AddProblemDetails()
            .AddScoped<ExceptionMiddleware>();

        // Api
        builder.Services.ConfigureApiServices(builder.Configuration);
        builder.Services
            .AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

        var app = builder.Build();

        app.Configure();

        await app.RunAsync();
    }
}

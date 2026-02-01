using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.ExternalClients;
using Peerly.Gateway.Hosting.Extensions;

namespace Peerly.Gateway.Hosting;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Grpc
        builder.Services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        builder.Services.AddGrpcReflection();
        builder.Services.AddGrpcClients();

        // Services
        builder.Services
            .ConfigureAutoMapper()
            .AddMediatR();

        // Error handling
        builder.Services
            .AddProblemDetails(
                options =>
                {
                    options.CustomizeProblemDetails = context =>
                    {
                        context.ProblemDetails.Extensions.Remove("traceId");
                    };
                })
            .AddScoped<ExceptionMiddleware>();

        // Api
        builder.Services
            .AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

        // Authorization
        builder.Services.AddHttpContextAccessor();
        builder.Services
            .AddAuthConfiguration()
            .AddAuthServices();
        builder.Services.AddAuthConfig();

        builder.Services.AddMemoryCache();

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "Peerly Gateway API", Version = "v1" });

            options.AddSecurityDefinition("Bearer", new()
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Введите JWT: Bearer {token}"
            });

            options.AddSecurityRequirement(new()
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        var app = builder.Build();

        app.Configure();

        await app.RunAsync();
    }
}

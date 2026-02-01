using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Peerly.Gateway.Hosting.Swagger;

internal sealed class RequiredMemberSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var typeProperties = context.Type.GetProperties();

        foreach (var schemaPropertyName in schema.Properties.Keys)
        {
            var typeProperty = typeProperties.SingleOrDefault(p => ToCamelCase(p.Name) == schemaPropertyName)
                               ?? throw new MissingFieldException(
                                   $"Could not find property {schemaPropertyName} in {context.Type}, or several names conflict.");

            if (typeProperty.GetCustomAttribute<RequiredMemberAttribute>() is not null)
            {
                _ = schema.Required.Add(schemaPropertyName);
            }
        }
    }

    private static string ToCamelCase(string name)
    {
        return JsonNamingPolicy.CamelCase.ConvertName(name);
    }
}

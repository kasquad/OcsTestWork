using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using OcsTestWork.OrderApi.Infrastructure.ExceptionFilters;
using OcsTestWork.OrderApi.Infrastructure.StartupFilters;

namespace OcsTestWork.OrderApi.Infrastructure.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddHttp(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        return builder;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo() { Title = "OcsTestWork.OrderApi" });
            options.CustomSchemaIds(s => s.FullName);

            // Add ability show comments above class in swagger
            var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

            options.IncludeXmlComments(xmlFilePath);
        });

        // TODO: Find why this broke endpoints
        // builder.Services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
        return builder;
    }
}
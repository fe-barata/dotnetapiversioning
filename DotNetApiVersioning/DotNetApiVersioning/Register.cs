using System.Text.Json;
using System.Text.Json.Serialization;
using Asp.Versioning;
using DotNetApiVersioning.Features.Catalog.V1;
using DotNetApiVersioning.Features.Catalog.V2;

namespace DotNetApiVersioning;

public static class Register
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.ConfigureCatalogServices();

        builder.ConfigureSwagger();

        builder.ConfigureVersioning();
    }

    private static void ConfigureCatalogServices(this WebApplicationBuilder builder)
    {
        // Register version-specific services
        builder.Services.AddScoped<ICatalogV1Service, CatalogV1Service>();
        builder.Services.AddScoped<ICatalogV2Service, CatalogV2Service>();
    }

    private static void ConfigureSwagger(this WebApplicationBuilder builder)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    private static void ConfigureVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
                {
                    // Default API versioning configuration
                    options.DefaultApiVersion = new ApiVersion(2);
                    // Report API versions in the response headers (e.g., "api-supported-versions" and "api-deprecated-versions")
                    options.ReportApiVersions = true;
                    // Uses the default API version when not specified
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    // Use the URL segment to specify the API version
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                }
            )
            // Add API versioning to the MVC pipeline (required for Controllers)
            .AddMvc()
            // Helps to generate Swagger documentation for each API version
            .AddApiExplorer(options =>
            {
                // Use the API version in the group name for Swagger
                options.GroupNameFormat = "'v'V";
                // Substitute the API version in the URL
                options.SubstituteApiVersionInUrl = true;
            })
            ;
    }
}
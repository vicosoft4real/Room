using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using OpenApiSecurityScheme = NSwag.OpenApiSecurityScheme;

namespace Room.Assignment.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyExtensions
    {
        /// <summary>
        /// Adds the document swagger.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void AddDocSwagger(this IServiceCollection service)
        {
            service.AddSwaggerDocument(x =>
            {
                x.GenerateXmlObjects = true;
                x.GenerateEnumMappingDescription = true;
                x.DocumentName = "Room Assignment Apis";
                x.Title = "Room Service Assignment";
                x.Description = "The is Service Assignment Apis";
                x.AddSecurity("oauth2", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the text-box: Bearer {your JWT token}.",
                    Scheme = "Bearer"
                });
                x.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("oauth2"));
            });
        }

        /// <summary>
        /// Uses the document swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseDocSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(s =>
            {
                s.Path = "";
                s.DocumentTitle = "Room Services Api";
            });
            app.UseReDoc(d =>
            {
                d.Path = "/redoc";
            });
        }
        /// <summary>
        /// Adds the API version.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void AddApiVersion(this IServiceCollection service)
        {
            service.AddApiVersioning(config =>
            {

                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

    }
}

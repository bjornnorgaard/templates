using DAA.Platform.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DAA.Platform.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddDaaSwagger(this IServiceCollection services,
                                         IConfiguration configuration)
        {
            var options = new ApplicationOptions(configuration);

            services.AddSwaggerGen(o =>
            {
                o.CustomSchemaIds(t => t.FullName);
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = options.ApplicationName, Version = "v1"
                });
            });
        }

        public static void UseDaaSwagger(this IApplicationBuilder app,
                                         IConfiguration configuration)
        {
            var options = new ApplicationOptions(configuration);

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", options.ApplicationName);
                o.RoutePrefix = string.Empty;
            });
        }
    }
}

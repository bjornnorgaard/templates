using DAA.Platform.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAA.Platform
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDaaPlatform(this IServiceCollection services,
                                                        IConfiguration configuration)
        {
            services.AddDasSwagger(configuration);
            services.AddDasLogging(configuration);

            return services;
        }

        public static IApplicationBuilder UseDaaPlatform(this IApplicationBuilder app,
                                                         IConfiguration configuration)
        {
            app.UseDasSwagger(configuration);
            app.UseDasMiddleware();

            return app;
        }
    }
}

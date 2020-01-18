using System;
using Api.Web.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;

namespace Api.Web.Configurations
{
    public static class LoggingExtension
    {
        public static IServiceCollection AddLogger(this IServiceCollection services,
                                                   IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var o = new LoggingOptions();
            configuration.Bind(nameof(LoggingOptions), o);

            Log.Logger = new LoggerConfiguration()
                         .ReadFrom.Configuration(configuration)
                         .Enrich.WithProperty("environment", environment)
                         .Enrich.WithProperty("system", o.SystemName)
                         .Enrich.WithExceptionDetails()
                         .Enrich.FromLogContext()
                         .WriteTo
                         .RollingFile($"C:/logs/{o.SystemName}/{o.SystemName}-{environment}-{{Date}}.txt")
                         .WriteTo.Console()
                         .CreateLogger();

            return services;
        }
    }
}

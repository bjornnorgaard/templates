using System;
using DAA.Platform.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DAA.Platform.Configurations
{
    public static class LoggingConfiguration
    {
        public static void AddDaaLogging(this IServiceCollection services,
                                         IConfiguration configuration)
        {
            Console.WriteLine("Configuring logger...");

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var options = new LoggingOptions(configuration);

            var logFilePath = $"{options.LogFileRootPath}/{options.ApplicationName}/log-.txt";

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("LoggingOptions", options, true)
                .Enrich.WithProperty("Environment", environment)
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Successfully configured logger.");
        }
    }
}

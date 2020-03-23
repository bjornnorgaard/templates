using Microsoft.Extensions.Configuration;

namespace DAA.Platform.Options
{
    internal class LoggingOptions : AbstractOptions
    {
        public string LogFileRootPath { get; set; }
        public string ApplicationName { get; set; }

        public LoggingOptions(IConfiguration configuration) : base(configuration) { }
    }
}

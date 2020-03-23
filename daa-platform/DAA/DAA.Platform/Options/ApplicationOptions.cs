using Microsoft.Extensions.Configuration;

namespace DAA.Platform.Options
{
    internal class ApplicationOptions : AbstractOptions
    {
        public string ApplicationName { get; set; }
        public ApplicationOptions(IConfiguration configuration) : base(configuration) { }
    }
}

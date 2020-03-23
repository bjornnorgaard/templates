using System.Linq;
using DAA.Platform.Exceptions;
using Microsoft.Extensions.Configuration;

namespace DAA.Platform.Options
{
    public class AbstractOptions
    {
        /// <summary>
        ///     Binds section of configuration to matching properties of child.
        /// </summary>
        /// <param name="configuration"></param>
        protected AbstractOptions(IConfiguration configuration)
        {
            var thisTypeName = ToString().Split('.').Last();

            configuration.GetSection(thisTypeName).Bind(this);

            var nulls = GetType()
                .GetProperties()
                .Where(p => GetType().GetProperty(p.Name)?.GetValue(this, null) == null)
                .Select(p => p.Name)
                .ToList();

            if (nulls.Any())
            {
                var error = $"Fields without value in {GetType().Name}: {string.Join(", ", nulls)}";
                throw new ConfigurationException(error);
            }
        }
    }
}

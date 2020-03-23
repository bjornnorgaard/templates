using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace TMP.Api.Options
{
    public class AbstractOptions
    {
        /// <summary>
        /// Binds section of configuration to matching properties of child.
        /// </summary>
        /// <param name="configuration"></param>
        protected AbstractOptions(IConfiguration configuration)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            var thisTypeName = ToString().Split('.').Last();

            configuration.GetSection(thisTypeName).Bind(this);

            var nullValues = GetType()
                .GetProperties()
                .Where(p => GetType().GetProperty(p.Name)?.GetValue(this, null) == null)
                .Select(p => p.Name)
                .ToList();
            
            if (nullValues.Any())
            {
                var error = $"Found properties without value in {GetType().Name}: {string.Join(", ", nullValues)}";
                throw new ConfigurationException(error);
            }
        }
    }

    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) : base(message) { }
    }
}

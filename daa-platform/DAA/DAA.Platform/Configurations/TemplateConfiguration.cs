using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DAA.Platform.Configurations
{
    public static class TemplateConfiguration
    {
        public static void AddDasService(this IServiceCollection services) { }

        public static void UseDasService(this IApplicationBuilder app) { }
    }
}

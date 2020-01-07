using Microsoft.Extensions.DependencyInjection;
using Api.Web.Filters;

namespace Api.Web.Configurations
{
    public static class MvcExtension
    {
        public static IMvcBuilder AddControllersWithFilters(this IServiceCollection services)
        {
            return services.AddControllers(o => { o.Filters.Add<ExceptionFilter>(); })
                           .AddApplicationPart(typeof(Startup).Assembly);
        }
    }
}





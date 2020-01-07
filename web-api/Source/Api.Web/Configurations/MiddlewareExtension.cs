using Microsoft.AspNetCore.Builder;
using Api.Web.Middleware;

namespace Api.Web.Configurations
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            // Order is important!
            app.UseMiddleware<CorrelationMiddleware>();
            app.UseMiddleware<RequestLoggerMiddleware>();
            app.UseMiddleware<SlowRequestLoggerMiddleware>();

            return app;
        }
    }
}





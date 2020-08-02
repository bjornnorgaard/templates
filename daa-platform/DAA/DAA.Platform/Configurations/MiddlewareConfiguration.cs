using DAA.Platform.Middleware;
using Microsoft.AspNetCore.Builder;

namespace DAA.Platform.Configurations
{
    public static class MiddlewareConfiguration
    {
        public static void UseDaaMiddleware(this IApplicationBuilder app)
        {
            // Order is important!
            app.UseMiddleware<CorrelationMiddleware>();
            app.UseMiddleware<RequestLoggerMiddleware>();
            app.UseMiddleware<SlowRequestLoggerMiddleware>();
        }
    }
}

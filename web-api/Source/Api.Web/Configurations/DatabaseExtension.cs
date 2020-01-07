using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Repository;

namespace Api.Web.Configurations
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(
                o => { o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });

            services.AddScoped<IContext>(ctx => ctx.GetService<Context>());

            return services;
        }

        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction()) return app;

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                context.Database.Migrate();

                if (!context.Pets.Any())
                {
                    var pets = new List<Pet>
                    {
                        new Pet { Name = "Fluffy", Age = 4 },
                        new Pet { Name = "Kisser", Age = 15 },
                        new Pet { Name = "Garfield", Age = 7 }
                    };
                    context.AddRange(pets);
                    context.SaveChanges();
                }
            }

            return app;
        }
    }
}

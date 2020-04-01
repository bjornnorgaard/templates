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
        public static IServiceCollection AddDatabase(this IServiceCollection services,
                                                     IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IContext>(ctx => ctx.GetService<Context>());

            return services;
        }

        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app,
                                                         IWebHostEnvironment env)
        {
            if (env.IsProduction()) return app;

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                context.Database.Migrate();

                if (!context.Persons.Any())
                {
                    var pets = new List<Person>
                    {
                        new Person { Name = "Simon Says", Age = 4 },
                        new Person { Name = "John Doe", Age = 15 },
                        new Person { Name = "Anders And", Age = 7 }
                    };
                    context.AddRange(pets);
                    context.SaveChanges();
                }
            }

            return app;
        }
    }
}

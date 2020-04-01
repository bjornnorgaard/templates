using System;
using System.Collections.Generic;
using System.Linq;
using DAA.Platform;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Users;
using Users.Database;

namespace Users
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDaaPlatform(Configuration);

            var connectionString = Configuration.GetConnectionString("Users");
            Console.WriteLine(connectionString);
            services.AddDbContext<UsersContext>(o => o.UseSqlServer(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseDaaPlatform(Configuration);
            app.UseEndpoints(ep => ep.MapControllers());

            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<UsersContext>();
            context.Database.Migrate();

            if (!context.Users.Any())
            {
                var list = new List<User>
                {
                    new User { Name = "John Doe", Age = 42 },
                    new User { Name = "Simon Says", Age = 15 },
                    new User { Name = "Bob Do", Age = 42 },
                };
                context.Users.AddRange(list);
                context.SaveChanges();
            }
        }
    }
}

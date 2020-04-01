using Microsoft.EntityFrameworkCore;
using Models.Users;

namespace Users.Database
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

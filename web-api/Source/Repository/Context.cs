using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class Context : DbContext, IContext
    {
        public DbSet<Pet> Pets { get; set; }

        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

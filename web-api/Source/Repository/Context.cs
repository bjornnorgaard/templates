using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Extensions;

namespace Repository
{
    public class Context : DbContext, IContext
    {
        public DbSet<Person> Persons { get; set; }
        
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            modelBuilder.SetupTemporalEntities<Person>();
            base.OnModelCreating(modelBuilder);
        }
    }
}

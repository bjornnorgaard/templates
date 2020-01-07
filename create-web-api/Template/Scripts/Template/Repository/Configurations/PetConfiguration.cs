using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Repository.Configurations
{
    public class [Entity]Configuration : IEntityTypeConfiguration<[Entity]>
    {
        public void Configure(EntityTypeBuilder<[Entity]> builder)
        {
            builder.HasKey(p => p.Id);
            // TODO: Configures additional properties.
        }
    }
}

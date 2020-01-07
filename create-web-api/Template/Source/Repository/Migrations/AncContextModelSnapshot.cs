using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Migrations
{
    [DbContext(typeof(Context))]
    internal class AncContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0")
                        .HasAnnotation("Relational:MaxIdentifierLength", 128)
                        .HasAnnotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity(
                "Models.Pet",
                b =>
                {
                    b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");

                    b.Property<int>("Age").HasColumnType("int").HasMaxLength(5);

                    b.Property<string>("Name").HasColumnType("nvarchar(15)").HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}

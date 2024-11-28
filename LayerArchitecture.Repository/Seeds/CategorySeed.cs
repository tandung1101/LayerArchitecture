using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LayerArchitecture.Core.Model;

namespace LayerArchitecture.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = Guid.Parse("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), Name = "Pencil" },
                new Category { Id = Guid.Parse("9b1ec4d7-39f7-493a-bef4-4bcff24da0d3"), Name = "Book" },
                new Category { Id = Guid.Parse("d2f2c4e6-6a5b-4b78-bcb5-4d56a8e17e9f"), Name = "Handbook" }
            );
        }
    }
}

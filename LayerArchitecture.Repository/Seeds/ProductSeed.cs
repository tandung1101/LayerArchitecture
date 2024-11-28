using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LayerArchitecture.Core.Model;

namespace LayerArchitecture.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("6f9a9c21-4cfa-4b52-1111-c2b8d7e26711"),
                    CategoryId = Guid.Parse("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), // Pencil
                    Name = "Pen 1",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("6f9a9c21-4cfa-4b52-2222-c2b8d7e26711"),
                    CategoryId = Guid.Parse("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), // Pencil
                    Name = "Pen 2",
                    Price = 200,
                    Stock = 30,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("6f9a9c21-4cfa-4b52-3333-c2b8d7e26711"),
                    CategoryId = Guid.Parse("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), // Pencil
                    Name = "Pen 3",
                    Price = 600,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("6f9a9c21-4cfa-4b52-4444-c2b8d7e26711"),
                    CategoryId = Guid.Parse("9b1ec4d7-39f7-493a-bef4-4bcff24da0d3"), // Book
                    Name = "Book 1",
                    Price = 600,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("6f9a9c21-4cfa-4b52-5555-c2b8d7e26711"),
                    CategoryId = Guid.Parse("9b1ec4d7-39f7-493a-bef4-4bcff24da0d3"), // Book
                    Name = "Book 2",
                    Price = 6600,
                    Stock = 320,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}

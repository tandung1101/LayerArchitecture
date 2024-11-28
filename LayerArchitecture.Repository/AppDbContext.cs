using System.Reflection;
using Microsoft.EntityFrameworkCore;
using LayerArchitecture.Core;
using LayerArchitecture.Core.Model;
using Microsoft.Extensions.Configuration;

namespace LayerArchitecture.Repository
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration? _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration? configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductFeature> ProductFeatures => Set<ProductFeature>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("LayerArchitecture.Repository"));
            }
        }
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;

                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = Guid.NewGuid(),
                Color = "Red",
                Height = 100,
                Width = 200,
                ProductId = Guid.Parse("6f9a9c21-4cfa-4b52-1111-c2b8d7e26711")
            },
                new ProductFeature()
                {
                    Id = Guid.NewGuid(),
                    Color = "Blue",
                    Height = 300,
                    Width = 200,
                    ProductId = Guid.Parse("6f9a9c21-4cfa-4b52-2222-c2b8d7e26711")
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

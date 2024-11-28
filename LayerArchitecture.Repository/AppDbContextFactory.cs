using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LayerArchitecture.Repository
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=192.168.200.125,1433;Initial Catalog=LayerArchitecture;User Id=NewUser;Password=StrongPassword123!;Persist Security Info=False",
                b => b.MigrationsAssembly("LayerArchitecture.Repository"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

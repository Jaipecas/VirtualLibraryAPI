using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VirtualLibraryDbContext>
    {
        public VirtualLibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VirtualLibraryDbContext>();

            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "VirtualLibraryAPI"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new VirtualLibraryDbContext(optionsBuilder.Options);
        }
    }
}

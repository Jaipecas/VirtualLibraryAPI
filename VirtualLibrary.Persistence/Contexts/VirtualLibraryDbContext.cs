using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Persistence.Contexts
{
    public class VirtualLibraryDbContext : IdentityDbContext<User>
    {
        public VirtualLibraryDbContext(DbContextOptions<VirtualLibraryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);         
        }

        public DbSet<Product> Products { get; set; }
    }
}

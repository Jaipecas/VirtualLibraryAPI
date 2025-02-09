using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Persistence.Contexts
{
    public class VirtualLibraryDbContext : IdentityDbContext<IdentityUser>
    {
        public VirtualLibraryDbContext(DbContextOptions<VirtualLibraryDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

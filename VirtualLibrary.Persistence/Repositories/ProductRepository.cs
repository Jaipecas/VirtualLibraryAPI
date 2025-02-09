using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProducts
    {
        public ProductRepository(VirtualLibraryDbContext context) : base(context)
        {
        }
    }
}

using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.UnitsOfWork
{
    public class VirtualLibraryUnitOfWork : IVirtualLibraryUnitOfWork
    {
        private readonly VirtualLibraryDbContext _virtualLibraryDbContext;
        public IProducts Products {get;}

        public VirtualLibraryUnitOfWork(VirtualLibraryDbContext VirtualLibraryDbContext, IProducts products)
        {
            _virtualLibraryDbContext = VirtualLibraryDbContext;
            Products = products;
        }

        public async Task<int> Save() => await _virtualLibraryDbContext.SaveChangesAsync();

        public void Dispose() => _virtualLibraryDbContext.Dispose();
    }
}

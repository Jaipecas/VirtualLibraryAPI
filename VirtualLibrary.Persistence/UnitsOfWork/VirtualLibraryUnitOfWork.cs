using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.UnitsOfWork
{
    public class VirtualLibraryUnitOfWork : IVirtualLibraryUnitOfWork
    {
        private readonly VirtualLibraryDbContext _virtualLibraryDbContext;
        public IUserRepository Users { get;}

        public VirtualLibraryUnitOfWork(VirtualLibraryDbContext VirtualLibraryDbContext, IUserRepository users)
        {
            _virtualLibraryDbContext = VirtualLibraryDbContext;
            Users = users;
        }

        public async Task<int> SaveChanges() => await _virtualLibraryDbContext.SaveChangesAsync();
    }
}

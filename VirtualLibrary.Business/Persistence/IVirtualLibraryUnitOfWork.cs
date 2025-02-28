
using VirtualLibrary.Application.Persistence.Repositories;

namespace VirtualLibrary.Application.Persistence
{
    public interface IVirtualLibraryUnitOfWork
    {
        IUserRepository Users { get; }
        Task<int> SaveChanges();
    }
}

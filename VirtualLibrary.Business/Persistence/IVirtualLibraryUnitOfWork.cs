
using VirtualLibrary.Application.Persistence.Repositories;

namespace VirtualLibrary.Application.Persistence
{
    public interface IVirtualLibraryUnitOfWork
    {
        IProducts Products { get; }
        IUserRepository Users { get; }
        Task<int> SaveChanges();
    }
}

using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.UnitsOfWork
{
    public class VirtualLibraryUnitOfWork : IVirtualLibraryUnitOfWork
    {
        private readonly VirtualLibraryDbContext _virtualLibraryDbContext;
        public IUserRepository Users { get;}

        public IStudyRoomRepository StudyRooms { get;}

        public VirtualLibraryUnitOfWork(VirtualLibraryDbContext VirtualLibraryDbContext, IUserRepository users, IStudyRoomRepository studyRooms)
        {
            _virtualLibraryDbContext = VirtualLibraryDbContext;
            Users = users;
            StudyRooms = studyRooms;
        }

        public async Task<int> SaveChanges() => await _virtualLibraryDbContext.SaveChangesAsync();
    }
}

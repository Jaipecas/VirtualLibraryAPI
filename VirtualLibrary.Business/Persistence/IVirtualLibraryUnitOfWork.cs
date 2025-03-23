
using VirtualLibrary.Application.Persistence.Repositories;

namespace VirtualLibrary.Application.Persistence
{
    public interface IVirtualLibraryUnitOfWork
    {
        IUserRepository Users { get; }
        IStudyRoomRepository StudyRooms { get; }
        IStudyRoomUserRepository StudyRoomUser { get; }
        INotification Notifications { get; }
        Task<int> SaveChanges();
    }
}


using VirtualLibrary.Application.Persistence.Repositories;

namespace VirtualLibrary.Application.Persistence
{
    public interface IVirtualLibraryUnitOfWork
    {
        IUserRepository Users { get; }
        IStudyRoomRepository StudyRooms { get; }
        IStudyRoomUserRepository StudyRoomUser { get; }
        INotificationRepository Notifications { get; }
        IUserFriendRepository UserFriends { get; }
        IBoardRepository Boards { get; }
        ICardListRepository CardLists { get; }
        ICardRepository Cards { get; }

        Task<int> SaveChanges();
    }
}

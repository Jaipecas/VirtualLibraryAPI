
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<List<Notification>?> GetNotifications(string userId);
    }
}


using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public NotificationRepository(VirtualLibraryDbContext virtualLibraryContext) : base(virtualLibraryContext)
        {
            _virtualLibraryContext = virtualLibraryContext;
        }

        public async Task<List<Notification>?> GetNotifications(string userId)
        {
            var notification = await _virtualLibraryContext.Notifications.Where(n => n.RecipientId == userId).ToListAsync();

            return notification;
        }

        public async Task<bool> DeleteRoomNotifications(int roomId, List<string> userIds)
        {
            var query = _virtualLibraryContext.Notifications
                .OfType<RoomNotification>()
                .Where(n => n.RoomId == roomId);

            if (userIds.Count > 0)           
                query = query.Where(n => userIds.Contains(n.RecipientId));
            
            var notificationsToDelete = await query.ToListAsync();

            if (notificationsToDelete.Count > 0)
            {
                _virtualLibraryContext.Notifications.RemoveRange(notificationsToDelete);
            }

            return true;
        }

    }
}


using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public  class NotificationRepository : GenericRepository<Notification>, INotificationRepository
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
    }
}

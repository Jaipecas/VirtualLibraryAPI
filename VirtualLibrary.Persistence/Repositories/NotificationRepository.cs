
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public  class NotificationRepository : GenericRepository<Notification>, INotification
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;

        public NotificationRepository(VirtualLibraryDbContext virtualLibraryContext) : base(virtualLibraryContext)
        {
            _virtualLibraryContext = virtualLibraryContext;
        }
    }
}

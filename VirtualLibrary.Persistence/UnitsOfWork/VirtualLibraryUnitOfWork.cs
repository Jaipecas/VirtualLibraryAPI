using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain;
using VirtualLibrary.Persistence.Contexts;
using VirtualLibrary.Persistence.Repositories;

namespace VirtualLibrary.Persistence.UnitsOfWork
{
    public class VirtualLibraryUnitOfWork : IVirtualLibraryUnitOfWork
    {
        private readonly VirtualLibraryDbContext _virtualLibraryDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private IStudyRoomRepository? _studyRooms;
        private IStudyRoomUserRepository? _studyRoomUser;
        private INotificationRepository? _notifications;
        private IUserFriendRepository? _userFriends;
        private IBoardRepository? _boards;
        private ICardListRepository? _cardLists;
        private ICardRepository? _cards;

        public IUserRepository Users { get; }
        public IStudyRoomRepository StudyRooms => _studyRooms ??= new StudyRoomRepository(_virtualLibraryDbContext);
        public IStudyRoomUserRepository StudyRoomUser => _studyRoomUser ??= new StudyRoomUserRepository(_virtualLibraryDbContext);
        public INotificationRepository Notifications => _notifications ??= new NotificationRepository(_virtualLibraryDbContext);
        public IUserFriendRepository UserFriends => _userFriends ??= new UserFriendRepository(_virtualLibraryDbContext);
        public IBoardRepository Boards => _boards ??= new BoardRepository(_virtualLibraryDbContext);
        public ICardListRepository CardLists => _cardLists ??= new CardListRepository(_virtualLibraryDbContext);
        public ICardRepository Cards => _cards ??= new CardRepository(_virtualLibraryDbContext);

        public VirtualLibraryUnitOfWork(VirtualLibraryDbContext VirtualLibraryDbContext, IHttpContextAccessor httpContextAccessor, IUserRepository users)
        {
            _virtualLibraryDbContext = VirtualLibraryDbContext;
            _httpContextAccessor = httpContextAccessor;
            Users = users;
        }

        public async Task<int> SaveChanges()
        {
            var entries = _virtualLibraryDbContext.ChangeTracker.Entries<GenericEntity>();

            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                    entry.Entity.UpdatedBy = userId;
                }
            }

            return await _virtualLibraryDbContext.SaveChangesAsync();

        }
    }
}


using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Domain.UserEntities;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public class UserFriendRepository : GenericRepository<UserFriend>, IUserFriendRepository
    {
        private readonly VirtualLibraryDbContext _virtualLibraryContext;
        public UserFriendRepository(VirtualLibraryDbContext context) : base(context)
        {
            _virtualLibraryContext = context;
        }

        public async Task<bool> ExistFriend(string friendId)
        {
            return await _virtualLibraryContext.UserFriends.AnyAsync(userFriend => userFriend.FriendId == friendId);
        }
    }
}

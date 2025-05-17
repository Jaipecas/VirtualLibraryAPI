
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

        public bool RemoveFriend(string userId, string friendId)
        {
            var userFriend = _virtualLibraryContext.UserFriends.SingleOrDefault(uf => uf.UserId == userId && uf.FriendId == friendId);

            if (userFriend != null) _virtualLibraryContext.UserFriends.Remove(userFriend);

            var friendUser = _virtualLibraryContext.UserFriends.SingleOrDefault(uf => uf.UserId == friendId && uf.FriendId == userId);

            if (friendUser != null) _virtualLibraryContext.UserFriends.Remove(friendUser);

            return true;
        }
    }
}

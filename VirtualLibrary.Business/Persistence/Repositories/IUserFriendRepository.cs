
using VirtualLibrary.Domain.UserEntities;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IUserFriendRepository : IGenericRepository<UserFriend>
    {
        Task<bool> ExistFriend(string friendId);
        bool RemoveFriend(string userId, string friendId);
    }
}

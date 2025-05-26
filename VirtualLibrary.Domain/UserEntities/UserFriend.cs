
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.UserEntities
{
    public class UserFriend : GenericEntity
    {
        public required string UserId { get; set; }
        private User? _user;
        public User? User
        {
            get => _lazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        public required string FriendId { get; set; }
        private User? _friend;
        public User? Friend
        {
            get => _lazyLoader.Load(this, ref _friend);
            set => _friend = value;
        }

        private readonly ILazyLoader _lazyLoader;
        public UserFriend(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;

        public UserFriend() { }
    }
}

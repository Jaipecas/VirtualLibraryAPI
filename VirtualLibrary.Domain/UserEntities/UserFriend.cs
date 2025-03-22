
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.UserEntities
{
    public class UserFriend : GenericEntity
    {
        public required string UserId { get; set; }
        public required User User { get; set; }

        public required string FriendId { get; set; }
        private User? _friend;
        public User Friend
        {
            get => _lazyLoader.Load(this, ref _friend);
            set => _friend = value;
        }

        private readonly ILazyLoader _lazyLoader;
        public UserFriend(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;

        public UserFriend() { }
    }
}

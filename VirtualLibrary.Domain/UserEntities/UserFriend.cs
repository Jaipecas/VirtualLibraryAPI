
namespace VirtualLibrary.Domain.UserEntities
{
    public class UserFriend : GenericEntity
    {
        public required string UserId { get; set; }
        public required User User { get; set; }

        public required string FriendId { get; set; }
        public required User Friend { get; set; }
    }
}

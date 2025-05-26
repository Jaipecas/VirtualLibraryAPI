
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VirtualLibrary.Domain.StudyRoomEntities;
using VirtualLibrary.Domain.UserEntities;

namespace VirtualLibrary.Domain
{
    public class User : IdentityUser
    {
        private readonly ILazyLoader _lazyLoader;
        public string? Logo { get; set; }

        private List<StudyRoom>? _studyRooms;
        public List<StudyRoom> StudyRooms
        {
            get => _lazyLoader.Load(this, ref _studyRooms);
            set => _studyRooms = value;
        }

        private List<UserFriend>? _userFriends;
        public List<UserFriend> UserFriends
        {
            get => _lazyLoader.Load(this, ref _userFriends);
            set => _userFriends = value;
        }

        public User(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public User() { }
    }
}

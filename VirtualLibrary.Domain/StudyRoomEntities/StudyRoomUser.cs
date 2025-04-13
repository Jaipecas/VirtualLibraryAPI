
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoomUser : GenericEntity
    {
        private readonly ILazyLoader _lazyLoader;

        public required int StudyRoomId { get; set; }
        private StudyRoom? _studyRoom;
        public StudyRoom? StudyRoom
        {
            get => _lazyLoader.Load(this, ref _studyRoom);
            set => _studyRoom = value;
        }

        public required string UserId { get; set; }
        private User? _user;
        public User? User
        {
            get => _lazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        public bool? IsAccepted { get; set; }
        public bool? IsConnected { get; set; }

        public StudyRoomUser(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public StudyRoomUser() { }
    }
}


using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoomUser : GenericEntity
    {
        private readonly ILazyLoader _lazyLoader;

        private StudyRoom _studyRoom;
        public required StudyRoom StudyRoom
        {
            get => _lazyLoader.Load(this, ref _studyRoom);
            set => _studyRoom = value;
        }

        private User _user;
        public required User User
        {
            get => _lazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        public bool? IsAccepted { get; set; }

        public StudyRoomUser(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public StudyRoomUser() { }
    }
}

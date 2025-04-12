
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoom : GenericEntity
    {
        private readonly ILazyLoader _lazyLoader;

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string OwnerId { get; set; }
        public DateTime? StartTime { get; set; }
        public bool? IsStudyTime { get; set; } 

        public List<RoomNotification>? RoomNotifications;


        private List<StudyRoomUser> _studyRoomUsers;
        public List<StudyRoomUser>? StudyRoomUsers
        {
            get => _lazyLoader.Load(this, ref _studyRoomUsers);
            set => _studyRoomUsers = value;
        }

        private Pomodoro? _pomodoro;
        public Pomodoro? Pomodoro
        {
            get => _lazyLoader.Load(this, ref _pomodoro);
            set => _pomodoro = value;
        }

        private User? _owner;
        public User? Owner
        {
            get => _lazyLoader.Load(this, ref _owner);
            set => _owner = value;
        }


        public StudyRoom(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public StudyRoom() { }
    }
}

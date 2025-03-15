
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoom : GenericEntity
    {
        private readonly ILazyLoader _lazyLoader;

        public required string Name { get; set; }
        public required string Description { get; set; }

        private List<StudyRoomUser>? _studyRoomUsers;
        public List<StudyRoomUser>? StudyRoomUsers
        {
            get => _lazyLoader.Load(this, ref _studyRoomUsers);
            set => _studyRoomUsers = value;
        }

        private Pomodoro? _pomodoro;
        public Pomodoro Pomodoro
        {
            get => _lazyLoader.Load(this, ref _pomodoro);
            set => _pomodoro = value;
        }

        public required string OwnerId { get; set; }
        private User? _owner;
        public User Owner
        {
            get => _lazyLoader.Load(this, ref _owner);
            set => _owner = value;
        }
        public StudyRoom(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public StudyRoom() { }
    }
}

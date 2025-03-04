

namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class StudyRoom : GenericEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<StudyRoomUser> StudyRoomUsers { get; set; }
        public required Pomodoro Pomodoro { get; set; }
        public required string OwnerId { get; set; }
        public required User Owner { get; set; }
    }
}

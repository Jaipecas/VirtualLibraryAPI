

namespace VirtualLibrary.Domain.StudyRoom
{
    public class StudyRoom : GenericEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<StudyRoomUser> StudyRoomUsers { get; set; }
        public required int PomodoroId { get; set; }
        public required Pomodoro Pomodoro { get; set; }
    }
}

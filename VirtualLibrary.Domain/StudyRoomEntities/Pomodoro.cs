
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class Pomodoro : GenericEntity
    {
        public required string Name { get; set; }
        public required DateTime PomodoroTime { get; set; }
        public required DateTime BreakTime { get; set; }  
        public required int StudyRoomId { get; set; }
        public required StudyRoom StudyRoom { get; set; }
    }
}

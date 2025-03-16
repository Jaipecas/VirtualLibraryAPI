
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class Pomodoro : GenericEntity
    {
        public required string Name { get; set; }
        public required int PomodoroTime { get; set; }
        public required int BreakTime { get; set; }  
        public required int StudyRoomId { get; set; }
        public required StudyRoom StudyRoom { get; set; }
    }
}

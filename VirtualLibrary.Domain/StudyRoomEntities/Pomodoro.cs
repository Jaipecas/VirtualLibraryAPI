
namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class Pomodoro : GenericEntity
    {
        public required int PomodoroTime { get; set; }
        public required int BreakTime { get; set; }  
        public required int StudyRoomId { get; set; }
        public StudyRoom? StudyRoom { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsStudyTime { get; set; }
    }
}


namespace VirtualLibrary.Domain.StudyRoom
{
    public class Pomodoro : GenericEntity
    {
        public required string Name { get; set; }
        public required DateTime PomodoroTime { get; set; }
        public required DateTime BreakTime { get; set; }        
    }
}

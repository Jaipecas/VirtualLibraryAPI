namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature
    {
        public class UpdateRoomTimerPomodoroDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
            public DateTime? EndTime { get; set; }
            public bool? IsStudyTime { get; set; }
        }
    }
}

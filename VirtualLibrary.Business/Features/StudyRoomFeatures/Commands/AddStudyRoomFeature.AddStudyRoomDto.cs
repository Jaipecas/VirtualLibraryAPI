
namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public class AddStudyRoomDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<AddStudyRoomUserDto> Users { get; set; }
            public required AddStudyRoomPomodoroDto Pomodoro { get; set; }
            public required AddStudyRoomUserDto Owner { get; set; }
        }

        public class AddStudyRoomUserDto
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }

        public class AddStudyRoomPomodoroDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
        }
    }
}

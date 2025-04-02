namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature
    {
        public class UpdateStudyRoomDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<UpdateStudyRoomDtoUserDto> Users { get; set; }
            public required UpdateStudyRoomDtoPomodoroDto Pomodoro { get; set; }
            public required UpdateStudyRoomDtoUserDto Owner { get; set; }
        }

        public class UpdateStudyRoomDtoUserDto
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }

        public class UpdateStudyRoomDtoPomodoroDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
        }

    }
}

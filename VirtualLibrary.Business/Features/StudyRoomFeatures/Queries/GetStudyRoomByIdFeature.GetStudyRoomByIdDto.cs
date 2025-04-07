namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature
    {
        public class GetStudyRoomByIdDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<GetStudyRoomByIdUserDto> Users { get; set; }
            public required GetStudyRoomByIdPomodoroDto Pomodoro { get; set; }
            public required GetStudyRoomByIdUserDto Owner { get; set; }
        }

        public class GetStudyRoomByIdPomodoroDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
        }

        public class GetStudyRoomByIdUserDto
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public string? Logo { get; set; }
        }
    }
}

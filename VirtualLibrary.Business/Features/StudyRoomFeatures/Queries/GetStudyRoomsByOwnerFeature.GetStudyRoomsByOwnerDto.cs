
namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature
    {
        public class StudyRoomDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<UserDto> Users { get; set; }
            public required PomodoroDto Pomodoro { get; set; }
            public required UserDto Owner { get; set; }
        }

        public class UserDto
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }

        public class PomodoroDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required DateTime PomodoroTime { get; set; }
            public required DateTime BreakTime { get; set; }
        }

    }
}

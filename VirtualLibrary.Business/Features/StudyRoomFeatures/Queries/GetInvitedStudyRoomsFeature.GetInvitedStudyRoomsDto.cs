namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetInvitedStudyRoomsFeature
    {
        public class GetInvitedStudyRoomsDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<GetInvitedStudyRoomsUserDto> Users { get; set; }
            public required GetInvitedStudyRoomsPomodoroDto Pomodoro { get; set; }
            public required GetInvitedStudyRoomsUserDto Owner { get; set; }
        }
        public class GetInvitedStudyRoomsUserDto
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
        }

        public class GetInvitedStudyRoomsPomodoroDto
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
        }
    }
}


using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public class AddStudyRoomCommand : IRequest<Result<AddStudyRoomDto>>
        {
            public required string Name { get; set; }
            public required string Description { get; set; }
            public List<string>? UsersIds { get; set; }
            public required PomodoroCommand Pomodoro { get; set; }
            public required string OwnerId { get; set; }
        }

        public class PomodoroCommand
        {
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
        }
    }
}

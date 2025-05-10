
using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public class AddStudyRoomCommand : IRequest<Result<AddStudyRoomDto>>
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public List<string>? UsersIds { get; set; }
            public PomodoroCommand? Pomodoro { get; set; }
            public string? OwnerId { get; set; }
        }

        public class PomodoroCommand
        {
            public string? Name { get; set; }
            public int? PomodoroTime { get; set; }
            public int? BreakTime { get; set; }
        }
    }
}

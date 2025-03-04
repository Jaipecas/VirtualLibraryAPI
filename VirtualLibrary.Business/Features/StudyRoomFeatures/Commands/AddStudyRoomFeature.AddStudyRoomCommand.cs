
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class AddStudyRoomFeature
    {
        public class AddStudyRoomCommand : IRequest<IActionResult>
        {
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<string> UsersIds { get; set; }
            public required PomodoroCommand Pomodoro { get; set; }
            public required string OwnerId { get; set; }
        }

        public class PomodoroCommand
        {
            public required string Name { get; set; }
            public required DateTime PomodoroTime { get; set; }
            public required DateTime BreakTime { get; set; }
        }
    }
}

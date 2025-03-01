
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures
{
    public partial class AddStudyRoomFeature
    {
        public class AddStudyRoomCommand : IRequest<IActionResult>
        {
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<string> UsersIds { get; set; }
            public required PomodoroCommand Pomodoro { get; set; }
        }

        public class PomodoroCommand
        {
            public required string Name { get; set; }
            public required DateTime PomodoroTime { get; set; }
            public required DateTime BreakTime { get; set; }
        }
    }
}

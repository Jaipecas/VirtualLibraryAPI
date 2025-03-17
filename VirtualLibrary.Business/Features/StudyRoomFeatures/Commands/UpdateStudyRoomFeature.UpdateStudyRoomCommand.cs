
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature
    {
        public class UpdateStudyRoomCommand : IRequest<IActionResult>
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public required List<string> UsersIds { get; set; }
            public required PomodoroUpdateCommand Pomodoro { get; set; }
        }

        public class PomodoroUpdateCommand
        {
            public required string Name { get; set; }
            public required DateTime PomodoroTime { get; set; }
            public required DateTime BreakTime { get; set; }
        }
    }

}

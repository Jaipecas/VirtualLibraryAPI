
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
            public List<AddStudyRoomNotification>? Notifications { get; set; }
        }

        public class PomodoroCommand
        {
            public required string Name { get; set; }
            public required int PomodoroTime { get; set; }
            public required int BreakTime { get; set; }
        }

        public class AddStudyRoomNotification
        {
            public required string SenderId { get; set; }
            public required string RecipientId { get; set; }
            public string? Title { get; set; }
            public string? Message { get; set; }
        }
    }
}

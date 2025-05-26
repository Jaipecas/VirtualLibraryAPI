
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateStudyRoomFeature
    {
        public class UpdateStudyRoomCommand : IRequest<Result<UpdateStudyRoomDto>>
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public List<string>? UsersIds { get; set; }
            public PomodoroUpdateCommand? Pomodoro { get; set; }
        }

        public class PomodoroUpdateCommand
        {
            public int? PomodoroTime { get; set; }
            public int? BreakTime { get; set; }
        }
    }

}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature
    {
        public class UpdateRoomTimerCommand : IRequest<IActionResult>
        {
            public required int RoomId { get; set; }
            public required bool IsStudyTime { get; set; }
        }
    }
}

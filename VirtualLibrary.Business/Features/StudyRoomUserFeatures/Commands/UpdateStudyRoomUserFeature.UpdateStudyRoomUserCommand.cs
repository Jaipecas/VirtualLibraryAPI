using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserCommand : IRequest<IActionResult>
        {
            public required int RoomUserId { get; set; }
            public required bool IsConnected { get; set; }
        }
    }
}



using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures
{
    public class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserCommand : IRequest<IActionResult>
        {
            public required int RoomId { get; set; }
            public required bool IsStudyTime { get; set; }
        }
    }
}

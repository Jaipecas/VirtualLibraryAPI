using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries
{
    public partial class GetRoomUsersFeature
    {
        public class GetRoomUsersQuery : IRequest<IActionResult>
        {
            public required int RoomId { get; set; }
            public required bool IsConnected { get; set; }
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class UpdateStudyRoomUserFeature
    {
        public class UpdateStudyRoomUserCommand : IRequest<Result<UpdateStudyRoomUserDto>>
        {
            public required int RoomId { get; set; }
            public required string UserId { get; set; }
            public required bool IsConnected { get; set; }
        }
    }
}


using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature
    {
        public class UpdateRoomTimerCommand : IRequest<Result<UpdateRoomTimerPomodoroDto>>
        {
            public required int RoomId { get; set; }
            public required bool IsStudyTime { get; set; }
        }
    }
}

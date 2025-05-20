using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class UpdateRoomTimerFeature
    {
        public class UpdateRoomTimerCommand : IRequest<Result<UpdateRoomTimerPomodoroDto>>
        {
            public int? RoomId { get; set; }
            public bool? IsStudyTime { get; set; }
            public bool? IsRestart { get; set; }
        }
    }
}

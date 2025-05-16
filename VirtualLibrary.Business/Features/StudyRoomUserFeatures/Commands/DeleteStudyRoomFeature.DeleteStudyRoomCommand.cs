
using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands
{
    public partial class DeleteStudyRoomFeature
    {
        public class DeleteStudyRoomUserCommand : IRequest<Result<bool>>
        {
            public int? RoomId { get; set; }
            public string? UserId { get; set; }
        }
    }
}

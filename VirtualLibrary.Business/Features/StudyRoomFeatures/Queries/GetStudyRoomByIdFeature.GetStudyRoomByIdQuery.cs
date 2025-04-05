using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature
    {
        public class GetStudyRoomByIdQuery : IRequest<IActionResult>
        {
            public required int RoomId { get; set; }
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetInvitedStudyRoomsFeature
    {
        public class GetInvitedStudyRoomsQuery : IRequest<IActionResult>
        {
            public required string UserId { get; set; }
        }
    }
}

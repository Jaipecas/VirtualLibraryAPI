
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomsByOwnerFeature
    {
        public class GetStudyRoomsByOwnerQuery : IRequest<IActionResult>
        {
            public required string UserId { get; set; }
        }
    }
}

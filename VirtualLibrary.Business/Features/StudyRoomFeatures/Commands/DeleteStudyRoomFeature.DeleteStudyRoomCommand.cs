
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class DeleteStudyRoomFeature
    {
        public class DeleteStudyRoomCommand : IRequest<IActionResult>
        {
            public required int StudyRoomId { get; set; }
        }
    }
}

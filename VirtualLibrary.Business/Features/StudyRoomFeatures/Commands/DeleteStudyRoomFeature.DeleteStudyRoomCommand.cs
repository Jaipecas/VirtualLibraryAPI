
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Commands
{
    public partial class DeleteStudyRoomFeature
    {
        public class DeleteStudyRoomCommand : IRequest<Result<bool>>
        {
            public required int StudyRoomId { get; set; }
        }
    }
}

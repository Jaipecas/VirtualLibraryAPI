using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.StudyRoomFeatures.Queries
{
    public partial class GetStudyRoomByIdFeature
    {
        public class GetStudyRoomByIdQuery : IRequest<Result<GetStudyRoomByIdDto>>
        {
            public required int RoomId { get; set; }
        }
    }
}
